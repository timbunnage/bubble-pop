using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Item
{

    ParticleSystem GrassParticles;
    // Start is called before the first frame update
    void Start()
    {
    GrassParticles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Collect();
        GrassParticles.Play();
    }
}
