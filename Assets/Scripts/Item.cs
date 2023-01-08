using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite uncollectedSprite;
    public Sprite collectedSprite;
    
    private bool _collected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Collect()
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
