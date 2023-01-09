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
        
        print(dialogueList[0].ToString());
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void IncrementStory()
    {
        print("Story progressed");

        // begin current dialogue
        if (dialogueList[storyProgress].paragraphList.Length > 0)
        {
            _dialogueManager.CallDialogue(dialogueList[storyProgress].paragraphList.ToList());
        }
        
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
