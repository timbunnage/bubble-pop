using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Item
{
    public string[] dialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Collect()
    {
        if (!Collected)
        {
            // speech bubble tech here
        }
        
        base.Collect();
    }
}
