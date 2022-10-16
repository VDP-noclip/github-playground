using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _lifetime = 3;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        Destroy(gameObject,_lifetime);
    }

    private void FixedUpdate()
    {
        _transform.position = _transform.position +
                              _speed * Time.fixedDeltaTime * _transform.up;
    }
}
