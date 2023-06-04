using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameButton : MonoBehaviour
{
    [SerializeField] private Material activeMaterial;
    [SerializeField] private Renderer buttonPresserRender;

    [FormerlySerializedAs("OnStep")]
    [SerializeField]
    private UnityEvent Active = new UnityEvent();

    [FormerlySerializedAs("OnLeave")]
    [SerializeField]
    private UnityEvent Deactive = new UnityEvent();

    private void Awake()
    {
    }
    private void SetActive()
    {
        buttonPresserRender.material.color = Color.green;
    }

    private void SetUnActive()
    {
        buttonPresserRender.material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IMovable movable))
        {
            SetActive();
            Active.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IMovable movable))
        {
            SetUnActive();
            Deactive.Invoke();
        }
    }

    public void LogText(string _text)
    {
        Debug.Log(_text);
    }
}
