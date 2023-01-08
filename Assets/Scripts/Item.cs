using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite[] CollectionSprites;
    protected StoryManager StoryManager;
    protected int CollectionStage = 0;
    protected bool Collected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Collect()
    {
        if (CollectionStage < CollectionSprites.Length && Collected == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = CollectionSprites[CollectionStage];
            gameObject.GetComponent<ParticleSystem>().Play();
            
            CollectionStage++;

            if (CollectionStage == CollectionSprites.Length)
            {
                Collected = true;
                return true;
            }
        }

        return false;
    }
}
