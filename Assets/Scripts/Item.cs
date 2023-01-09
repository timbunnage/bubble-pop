using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Item : MonoBehaviour
{
    public Sprite[] collectionSprites;
    public AudioClip[] collectionAudio;

    private int _collectionStage;
    private bool _collected;

    protected Color[] pixels;
    protected ParticleSystem ps;
    ParticleSystem.Particle[] particles;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    private void Update()
    {   

    }


    public virtual bool Collect()
    {
        if (_collectionStage >= collectionSprites.Length || _collected) return false;

        gameObject.GetComponent<SpriteRenderer>().sprite = collectionSprites[_collectionStage];
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<AudioSource>().clip = collectionAudio[Random.Range(0, collectionAudio.Length - 1)];
        gameObject.GetComponent<AudioSource>().Play();
            
        _collectionStage++;

        if (_collectionStage != collectionSprites.Length) return false;
        
        _collected = true;
        return true;
    }


    protected void initParticleColors() {
        // Get pixel colours
        // https://answers.unity.com/questions/1331022/55-particle-startcolor-warning.html
        ps = gameObject.GetComponent<ParticleSystem>();
        // psmain = ps.main;
        Texture2D t = gameObject.GetComponent<SpriteRenderer>().sprite.texture;
        int mipLevel = 0;
        pixels = t.GetPixels(mipLevel);

        particles = new ParticleSystem.Particle[ps.main.maxParticles];

    }

    // Sets the particle color to a random pixel from the sprite texture
    protected void setParticleColors() {
        // psmain.startColor = pixels[Random.Range(0, pixels.Length-1)];

        int numParticlesAlive = ps.GetParticles(particles);     // store in particles buffer
        for (int i = 0; i < numParticlesAlive; i++)
        {  
            if (particles[i].GetCurrentColor(ps) == Color.white) { 
                particles[i].color = pixels[Random.Range(0, pixels.Length-1)];
            }
            
        }
        ps.SetParticles(particles, numParticlesAlive);
    }
}
