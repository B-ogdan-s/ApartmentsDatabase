using System;
using System.Collections;
using System.Text;
using API.Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Api : MonoBehaviour
{
    public static Api Instance;
    
    public enum RequestType
    {
        GET,
        POST
    };

    private void Awake()
    {
        Instance = this;
    }

    public void SendRequest(string url, RequestType type, Request body, Action<string> onResponce = null)
    {
        StartCoroutine(Send(url, type, body, onResponce));
    }

    private IEnumerator Send(string url, RequestType type, Request body, Action<string> onResponce)
    {
        using (UnityWebRequest request = CreateRequest(url, type, body))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                onResponce?.Invoke(request.downloadHandler.text);    
            }
            else
            {
                Debug.LogError(request.error);
                onResponce?.Invoke(null);
            }
        }
    }

    private UnityWebRequest CreateRequest(string url, RequestType type, Request body)
    {
        UnityWebRequest request = null;
        if (type == RequestType.GET)
        {
            if (body != null)
            {
                url += "?" + ConvertToQueryString(body);
            }
            request = UnityWebRequest.Get(url);
            request.method = "GET";
        }
        else
        {
            request = UnityWebRequest.Put(url, JsonConvert.SerializeObject(body));
            request.method = "POST";
        }
        
        request.SetRequestHeader("accept", "application/json");
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }
    
    public static string ConvertToQueryString(Request obj)
    {
        StringBuilder queryString = new StringBuilder();
        var fields = obj.GetType().GetFields();

        foreach (var field in fields)
        {
            string propertyName = field.Name;
            string propertyValue = field.GetValue(obj)?.ToString();
            
            string encodedName = Uri.EscapeDataString(propertyName);
            string encodedValue = Uri.EscapeDataString(propertyValue);
            
            queryString.Append(encodedName);
            queryString.Append("=");
            queryString.Append(encodedValue);
            queryString.Append("&");
        }
        
        if (queryString.Length > 0)
        {
            queryString.Length--;
        }

        return queryString.ToString();
    }
}
