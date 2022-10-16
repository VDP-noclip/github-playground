using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class SpaceShipController : Nonexistingclass
{
    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    [SerializeField] private float thrustForce = 1f;
    [SerializeField] private float rotationSpeed = 45f;

    [SerializeField] private bool _invincible = false;
    private bool _coolDown = false;
    
    private Rigidbody2D _rigidbody;
    private SpaceShipThrust _spaceShipThrust;
    private GameObject _spaceShipThrustObject;
    private AsteroidFieldManager _asteroidFieldManager;

    private bool _thrust = false;
    private float _rotationMovement = 0f;

    [SerializeField] private MissileController _missileController;
    [SerializeField] private Transform _firingPosition;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody)
        {
            _rigidbody.gravityScale = 0f;
        }
        
        _spaceShipThrust = GetComponentInChildren<SpaceShipThrust>();
        if (_spaceShipThrust)
        {
            _spaceShipThrustObject = _spaceShipThrust.gameObject;
            _spaceShipThrustObject.SetActive(false);  
        }
    }

    public void Init(AsteroidFieldManager asteroidFieldManager)
    {
        _asteroidFieldManager = asteroidFieldManager;
    }

    // Update is called once per frame
    void Update()
    {
        _thrust = false;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _thrust = true;
            _spaceShipThrustObject.SetActive(true);
        }
        else
        {
            _spaceShipThrustObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MissileController missile = Instantiate(_missileController,
                _firingPosition.position,
                _firingPosition.rotation);
            AudioManager.Instance.PlayMissileSound();
        }

        _rotationMovement = 0f;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rotationMovement = rotationSpeed;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rotationMovement = -rotationSpeed;
        }
        
    }

    private void FixedUpdate()
    {
        if (_thrust)
        {
            _rigidbody.AddForce(transform.up*thrustForce, ForceMode2D.Impulse);
        }

        if (Mathf.Abs(_rotationMovement) > float.Epsilon)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation 
                                    + _rotationMovement*Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (_invincible || _coolDown)
        {
            return;
        }
        
        if (col.CompareTag("Enemy"))
        {
            if (_asteroidFieldManager)
            {
                _asteroidFieldManager.SpaceShipDestroyed();
            }
        }
    }
    
    public void ActivateCoolDown()
    {
        StartCoroutine(ActivateCoolDownCoroutine());
    }

    IEnumerator ActivateCoolDownCoroutine()
    {
        _coolDown = true;
        yield return BlinkCoroutine(_spriteRenderers, 5f, 2f);
        _coolDown = false;
        yield return null;
    }
    
    private IEnumerator BlinkCoroutine(SpriteRenderer[] spriteRenderers, float duration, float speed)
    {
        var elapsedTime = 0f;
        while( elapsedTime <= duration )
        {
            for (int i=0; i < spriteRenderers.Length; i++)
            {
                Color color = spriteRenderers[i].color;
                
                color.a = 0.25f + Mathf.PingPong( elapsedTime * speed, 0.75f );

                spriteRenderers[i].color = color;
            }
            
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        
        // resets all the alpha to one
        for (int i=0; i < spriteRenderers.Length; i++)
        {
            Color color = spriteRenderers[i].color;

            color.a = 1f;

            spriteRenderers[i].color = color;
        }
    }
}
