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

    // Start is called before the first frame update
    private void Start()
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
}
