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

    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;

    protected StoryManager StoryManager;
    protected DialogueManager DialogueManager;

    private Color[] _pixelColours;
    private ParticleSystem.EmitParams _emitParams;

    private const int MipLevel = 0;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        _particleSystem = gameObject.GetComponent<ParticleSystem>();
        
        StoryManager = FindObjectOfType<StoryManager>();
        DialogueManager = FindObjectOfType<DialogueManager>();
        
        _pixelColours = gameObject.GetComponent<SpriteRenderer>().sprite.texture.GetPixels(MipLevel);
    }

    // Update is called once per frame
    protected virtual void Update()
    {   

    }

    public virtual bool Collect()
    {
        if (_collectionStage >= collectionSprites.Length || _collected) return false;

        // Swap sprite
        _spriteRenderer.sprite = collectionSprites[_collectionStage];
        
        // Play particles
        foreach (var colour in _pixelColours)
        {
            _emitParams.startColor = colour;
            _particleSystem.Emit(_emitParams, 1);
        }
        
        // Play audio
        _audioSource.clip = collectionAudio[Random.Range(0, collectionAudio.Length - 1)];
        _audioSource.Play();
            
        _collectionStage++;

        if (_collectionStage != collectionSprites.Length) return false;
        
        _collected = true;
        return true;
    }
}
