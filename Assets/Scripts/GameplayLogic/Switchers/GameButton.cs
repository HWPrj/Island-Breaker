using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameButton : MonoBehaviour, ISwitcher
{
    [SerializeField] private Material activeMaterial;
    [SerializeField] private Renderer buttonPresserRender;


    public event UnityAction Activate;
    public event UnityAction Deactivate;

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

            Activate.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Moveable" || other.tag == "Player")
        {

            //... анимации и т.д.

            Deactivate.Invoke();
        }
    }

    // to remove after tests
    public void LogText(string _text)
    {
        Debug.Log(_text);
    }
}
