using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Button : MonoBehaviour
{
    [SerializeField] private Material activeMaterial;
    [SerializeField] private Renderer buttonPresserRender;

    [FormerlySerializedAs("OnStep")]
    [SerializeField]
    private UnityEvent OnStep = new UnityEvent();

    [FormerlySerializedAs("OnLeave")]
    [SerializeField]
    private UnityEvent OnLeave = new UnityEvent();

    private Material _unActiveMaterial;
    private void Awake()
    {
        _unActiveMaterial = GetComponent<Material>();
    }
    private void SetActive()
    {
        buttonPresserRender.material = activeMaterial;
    }

    private void SetUnActive()
    {
        buttonPresserRender.material = _unActiveMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Moveable" || other.tag == "Player")
        {

            //... анимации и т.д.

            OnStep.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Moveable" || other.tag == "Player")
        {

            //... анимации и т.д.

            OnLeave.Invoke();
        }
    }

    // to remove after tests
    public void LogText(string _text)
    {
        Debug.Log(_text);
    }
}
