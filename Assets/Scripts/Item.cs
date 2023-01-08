using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite collectedSprite;
    
    protected bool Collected = false;

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
        print("TEST");
        if (!Collected)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = collectedSprite;
            gameObject.GetComponent<ParticleSystem>().Play();
            
            Collected = true;
        }
    }
}
