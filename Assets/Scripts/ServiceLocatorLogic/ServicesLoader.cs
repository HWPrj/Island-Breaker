using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicesLoader : MonoBehaviour
{
    [SerializeField] private MobailInputService mobailInputService;

    private ServiceLocator<object> _serviceLocator;
    public ServiceLocator<object> ServiceLocator => _serviceLocator;
    private void Awake()
    {
        _serviceLocator = new ServiceLocator<object>();
        _serviceLocator.Register<IInputService>(mobailInputService);
    }
}
