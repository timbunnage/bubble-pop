using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Item
{
    [Serializable]
    public enum FlowerType
    {
        Undefined,
        Iris,
        IrisMetal,
        Tulip,
        TulipMetal,
        Violet,
        VioletMetal
    }
    public FlowerType flowerType;
    
    private StoryManager _storyManager; 
    
    // Start is called before the first frame update
    private void Start()
    {
        _storyManager = FindObjectOfType<StoryManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public override bool Collect()
    {
        if (!base.Collect()) return false;
        
        _storyManager.IncrementFlower(flowerType);
        
        return true;
    }
}
