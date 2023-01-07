using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool _collected = false;

    public Sprite uncollectedSprite;
    public Sprite collectedSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (_collected)
        {
            return;
        }
        else
        {
            _collected = true;

            GetComponent<SpriteRenderer>().sprite = collectedSprite;
            
            // particle animation here
        }
    }
}
