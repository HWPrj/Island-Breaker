using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private float speed;

    [SerializeField] private ServicesLoader servicesLoader;
    [SerializeField] private Rigidbody rigidbody;
    private IInputService inputService;
    private Vector3 _direction;
    private void Start()
    {
        inputService = servicesLoader.ServiceLocator.Get<IInputService>();  
        inputService.InputMove += OnInputMove;
        inputService.InputStopMove += OnStopInputMove;
    }
    public void OnInputMove(Vector2 direction)
    {
        _direction = direction;
    }
    private void OnStopInputMove()
    {
        _direction = Vector3.zero;
    }
    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(_direction.x, 0, _direction.y);
        Debug.Log(rigidbody.velocity);
        rigidbody.AddForce(direction * speed);
    }
}
