using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MobailInputService : MonoBehaviour, IInputService, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event UnityAction<Vector2> InputMove;
    public event UnityAction InputStopMove;

    private Vector2 _lastPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        _lastPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _lastPosition;
        InputMove?.Invoke(direction);
        _lastPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputStopMove?.Invoke();
    }
}
