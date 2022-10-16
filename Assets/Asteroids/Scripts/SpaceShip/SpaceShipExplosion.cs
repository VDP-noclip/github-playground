using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipExplosion : MonoBehaviour
{
    // https://www.youtube.com/watch?v=rcyQ4XdHdGw
    [SerializeField] private float _ExplosionDuration = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,_ExplosionDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
