using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public int storyProgress;
    public string[] dialogueList =
    {
        "Why hello there.\nWhat are you doing here.\nYou know this place is dangerous, right?",
        "Didn't I tell you to leave?\nYou are not welcome here.\nRun away, child."
    };

    public int irisCollected;
    public int irisMetalCollected ;
    public int tulipCollected;
    public int tulipMetalCollected;
    public int violetCollected;
    public int violetMetalCollected;
    public int grassDestroyed;
    
    private DialogueManager _dialogueManager; 
    
    // Start is called before the first frame update
    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void IncrementStory()
    {
        print("Story progressed");
        
        var currentDialogue = dialogueList[storyProgress].Split("\n").ToList();

        // begin current dialogue
        _dialogueManager.CallDialogue(currentDialogue);
        
        storyProgress++;
    }

    public void IncrementFlower(Flower.FlowerType flowerType)
    {
        switch (flowerType)
        {
            case Flower.FlowerType.Iris:
                IncrementStory();
                irisCollected++;
                break;
            case Flower.FlowerType.IrisMetal:
                irisMetalCollected++;
                break;
            case Flower.FlowerType.Tulip:
                IncrementStory();
                tulipCollected++;
                break;
            case Flower.FlowerType.TulipMetal:
                tulipMetalCollected++;
                break;
            case Flower.FlowerType.Violet:
                violetCollected++;
                IncrementStory();
                break;
            case Flower.FlowerType.VioletMetal:
                violetMetalCollected++;
                break;
            case Flower.FlowerType.Undefined:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void IncrementGrass()
    {
        grassDestroyed++;
    }
}
