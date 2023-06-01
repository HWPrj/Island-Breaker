using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class MobailInputService : MonoBehaviour, IInputService, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event UnityAction<Vector2> InputMove;
    private Vector2 _lastPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        _lastPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _lastPosition;
        InputMove?.Invoke(direction);
        Debug.Log(direction);
        _lastPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
