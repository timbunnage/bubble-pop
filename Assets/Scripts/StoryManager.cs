using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public int storyProgress;
    
    [Serializable]
    public class ParagraphList
    {
        public string[] paragraphList;
    }
    public ParagraphList[] dialogueList;
    
    public AudioClip[] AudioClips;
    public int[] AudioClipQueues;

    public int grassDestroyed;

    public Dictionary<Flower.FlowerType, int> Inventory = new();


    private DialogueManager _dialogueManager;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _audioSource = GetComponent<AudioSource>();

        // Initialise inventory
        foreach (var flowerType in Enum.GetValues(typeof(Flower.FlowerType)).Cast<Flower.FlowerType>())
        {
            Inventory.Add(flowerType, 0);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void IncrementStory()
    {
        // begin current dialogue
        if (dialogueList[storyProgress].paragraphList.Length > 0)
        {
            _dialogueManager.CallDialogue(dialogueList[storyProgress].paragraphList.ToList());
        }

        // Play music for story progress if applicable
        for (var i = 0; i < AudioClipQueues.Length; i++)
        {
            if (AudioClipQueues[i] != storyProgress) continue;
            _audioSource.clip = AudioClips[i];
            _audioSource.Play();
        }
        
        storyProgress++;
    }

    public void IncrementFlower(Flower.FlowerType flowerType)
    {
        Inventory[flowerType]++;
        
        switch (flowerType)
        {
            case Flower.FlowerType.Iris:
            case Flower.FlowerType.Tulip:
            case Flower.FlowerType.Violet:
                IncrementStory();
                break;
            case Flower.FlowerType.IrisMetal:
            case Flower.FlowerType.TulipMetal:
            case Flower.FlowerType.VioletMetal:
            case Flower.FlowerType.TentKey:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void IncrementGrass()
    {
        grassDestroyed++;
    }
}
