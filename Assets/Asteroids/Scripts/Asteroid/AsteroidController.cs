using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
    public enum Size
    {
        Small=0, Medium=1, Large=2
    }

    [SerializeField] private float _speed = 5f;

    [SerializeField] private float _rotationSpeed = 90f;

    private Transform _transform;

    private Vector3 _direction = Vector3.zero;
    private float _rotationDirection = 0f;

    private Size _size = Size.Large;


    private AsteroidFieldManager _asteroidFieldManager;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _direction = Vector3.right;
        _asteroidFieldManager = GameObject.FindObjectOfType<AsteroidFieldManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Random.value < 0.5f)
            _rotationDirection = 1f;
        else
            _rotationDirection = -1f;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
    
    public void SetSize(Size size)
    {
        _size = size;
    }
    
    public void SetScale(float scale)
    {
        _transform.localScale = new Vector3(scale, scale, _transform.localScale.z);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _transform.position = _transform.position
                              + _speed * Time.fixedDeltaTime * _direction;
        _transform.Rotate(0f,0f, 
            _rotationDirection*_rotationSpeed*Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Missile"))
        {
            Destroy(col.gameObject);
            
            _asteroidFieldManager.AsteroidDestroyed(_size, _transform.position);

            Destroy(gameObject);
        }
    }
}
