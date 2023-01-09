using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Item
{
    private StoryManager _storyManager; 
    
    // Start is called before the first frame update
    void Start()
    {

        initParticleColors();
        _storyManager = FindObjectOfType<StoryManager>();

    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void LateUpdate() {
        setParticleColors();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Collect())
        {
            _storyManager.IncrementGrass();
        }
    }
}
