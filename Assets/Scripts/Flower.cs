using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Collect()
    {
        bool collected = base.Collect();
        
        if (collected)
        {
            StoryManager.IncrementStory();
            return true;
        }

        return false;
    }
}
