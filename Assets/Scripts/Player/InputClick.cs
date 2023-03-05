using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 _startTouch = Vector2.zero;

    public event Action<float> SetHorizontalDirection;
    public event Action<float> SetVerticalDirection;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - _startTouch;

        SetHorizontalDirection?.Invoke(delta.x);
        SetVerticalDirection?.Invoke(-delta.y);

        _startTouch = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startTouch = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _startTouch = Vector2.zero;
    }

}
