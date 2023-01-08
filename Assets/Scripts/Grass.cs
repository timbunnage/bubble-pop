using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Item
{
    
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
        bool collected = Collect();
        
        if (collected)
        {
            StoryManager.GrassDestroyed++;
            print(StoryManager.GrassDestroyed);
        }
    }
}
