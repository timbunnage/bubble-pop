using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Item
{
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Collect())
        {
            StoryManager.GrassDestroyed++;
        }
    }
}
