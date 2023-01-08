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

        switch (flowerType)
        {
            case FlowerType.Iris:
                _storyManager.IncrementStory();
                break;
            case FlowerType.IrisMetal:
                break;
            case FlowerType.Tulip:
                _storyManager.IncrementStory();
                break;
            case FlowerType.TulipMetal:
                break;
            case FlowerType.Violet:
                _storyManager.IncrementStory();
                break;
            case FlowerType.VioletMetal:
                break;
            case FlowerType.Undefined:
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        return true;
    }
}
