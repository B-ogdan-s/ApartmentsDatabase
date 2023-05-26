using API.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CastomizationList : MonoBehaviour
{
    [SerializeField] private CastomizationPanel _panelPrefab;
    [SerializeField] private Transform _parents;

    private List<CastomizationPanel> _panelList = new List<CastomizationPanel>();

    private GameObject[] _object;
    private int _id;

    public void SetObj(GameObject[] obj, int id)
    {
        _object = obj;
        _id = id;
    }

    public void UpdateCustomization(InputType type)
    {
        foreach (CastomizationPanel panel in _panelList)
        {
            Destroy(panel.gameObject);
        }
        _panelList.Clear();

        switch (type)
        {
            case InputType.Material:
                Api.Instance.SendRequest("https://test-server-1w9i.onrender.com/materials", Api.RequestType.GET, null, responce =>
                {
                    if (responce != null)
                    {
                        var materials = JsonConvert.DeserializeObject<MaterialResponce[]>(responce);
                        foreach (var material in materials)
                        {
                            CastomizationPanel p = Instantiate(_panelPrefab);
                            p.transform.SetParent(_parents);
                            p.transform.localScale = Vector3.one;
                            p.Spawn(material);
                            p.SetObj(_object, _id);
                            _panelList.Add(p);
                        }
                    }
                });
                break;
            case InputType.Model:
                Api.Instance.SendRequest("https://test-server-1w9i.onrender.com/models", Api.RequestType.GET, null, responce =>
                {
                    if (responce != null)
                    {
                        var materials = JsonConvert.DeserializeObject<ModelResponce[]>(responce);
                        foreach (var material in materials)
                        {
                            CastomizationPanel p = Instantiate(_panelPrefab);
                            p.transform.SetParent(_parents);
                            p.transform.localScale = Vector3.one;
                            p.Spawn(material);
                            p.SetObj(_object, _id);
                            _panelList.Add(p);
                        }
                    }
                });
                break;
        }
    }
}
