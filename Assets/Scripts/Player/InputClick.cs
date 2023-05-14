using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] RayInfo _info;
    private Vector2 _startTouch = Vector2.zero;
    private bool _isClick = false;

    public event Action<float> SetHorizontalDirection;
    public event Action<float> SetVerticalDirection;

    public void OnDrag(PointerEventData eventData)  
    {
        _isClick = false;
        Vector2 delta = eventData.position - _startTouch;

        SetHorizontalDirection?.Invoke(delta.x);
        SetVerticalDirection?.Invoke(-delta.y);

        _startTouch = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isClick = true;
        _startTouch = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(_isClick)
        {
            CheckRay(eventData.position);
        }

        _startTouch = Vector2.zero;
    }

    private void CheckRay(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);

        if(Physics.Raycast(ray, out RaycastHit hit, _info.Distans, _info.LayerMask))
        {
            if(hit.transform.TryGetComponent(out Customization test))
            {
                test.Click();
            }
        }
    }
}

[Serializable]
public class RayInfo
{
    [SerializeField, Min(0)] private float _distans;
    [SerializeField] private LayerMask _layerMask;

    public float Distans
    {
        get 
        {
            if (_distans == 0)
                return Mathf.Infinity;

            return _distans;
        }
    }
    public LayerMask LayerMask => _layerMask;
}
