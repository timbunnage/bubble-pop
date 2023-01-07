using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float animLength = 0.1f; // Animation length in seconds
    public float animSpeed = 20f; 
    private float _animProgress = 0f;
    private bool _collected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_collected)
        {
            if (_animProgress <= animLength)
            {
                DeathEffect();
            }
            else
            {
                // Item picked up
                Destroy(gameObject);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        _collected = true;
    }

    void DeathEffect()
    {
        var i = Time.deltaTime * animSpeed;
        _animProgress += i;
        
        transform.localScale *= 1 + i;
        GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1 - _animProgress / animLength);
    }
}
