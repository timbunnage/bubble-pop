using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Broken : Item
{
    public int[] recipeInput = {0, 0, 0, 0, 0, 0, 0};

    public Obstacle linkedObstacle;
    
    private Dictionary<Flower.FlowerType, int> _recipe = new();

    public string[] firstDialogueList =
    {
        "Oh, what's this?",
        "It seems to be broken.",
        "I gotta fix it!"
    };

    public string[] collectedDialogueList =
    {
        "... It's fixed!"
    };
    
    public string[] alreadyCollectedDialogueList =
    {
        "I already fixed it."
    };

    private bool _investigated;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _recipe.Add(Flower.FlowerType.Iris, recipeInput[0]);
        _recipe.Add(Flower.FlowerType.IrisMetal, recipeInput[1]);
        _recipe.Add(Flower.FlowerType.Tulip, recipeInput[2]);
        _recipe.Add(Flower.FlowerType.TulipMetal, recipeInput[3]);
        _recipe.Add(Flower.FlowerType.Violet, recipeInput[4]);
        _recipe.Add(Flower.FlowerType.VioletMetal, recipeInput[5]);
        _recipe.Add(Flower.FlowerType.TentKey, recipeInput[6]);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override bool Collect() {
        if (Collected) // Already collected
        {
            DialogueManager.CallDialogue(alreadyCollectedDialogueList.ToList());
            return base.Collect();
        }
        
        if (Enum.GetValues(typeof(Flower.FlowerType)).Cast<Flower.FlowerType>().All(
                flowerType => StoryManager.Inventory[flowerType] >= _recipe[flowerType])) // Recipe satisfied, first collection
        {
            DialogueManager.CallDialogue(collectedDialogueList.ToList());
            
            // Subtract resources
            foreach (var flowerType in Enum.GetValues(typeof(Flower.FlowerType)).Cast<Flower.FlowerType>())
            {
                StoryManager.Inventory[flowerType] -= _recipe[flowerType];
            }

            linkedObstacle.Clear();
            
            return base.Collect();
        }
        
        if (!_investigated)
        {
            DialogueManager.CallDialogue(firstDialogueList.ToList());
            _investigated = true;
            return false;
        }

        var recipePrompt = "I need";
        for (var i = 0; i < recipeInput.Length; i++)
        {
            if (recipeInput[i] == 0) continue;

            switch (i)
            {
                case 0:
                    recipePrompt += " " + (recipeInput[i] - StoryManager.Inventory[Flower.FlowerType.Iris]) + " Iris";
                    break;
                case 1:
                    recipePrompt += " " + (recipeInput[i] - StoryManager.Inventory[Flower.FlowerType.IrisMetal]) + " Aluminium";
                    break;
                case 2:
                    recipePrompt += " " + (recipeInput[i] - StoryManager.Inventory[Flower.FlowerType.Tulip]) + " Tulip";
                    break;
                case 3:
                    recipePrompt += " " + (recipeInput[i] - StoryManager.Inventory[Flower.FlowerType.TulipMetal]) + " Copper";
                    break;
                case 4:
                    recipePrompt += " " + (recipeInput[i] - StoryManager.Inventory[Flower.FlowerType.Violet]) + " Violet";
                    break;
                case 5:
                    recipePrompt += " " + (recipeInput[i] - StoryManager.Inventory[Flower.FlowerType.VioletMetal]) + " Steel";
                    break;
                case 6:
                    recipePrompt += " " + (recipeInput[i] - StoryManager.Inventory[Flower.FlowerType.TentKey]) + " tent key";
                    break;
            }
        }

        string[] recipeDialogue = {recipePrompt};
        DialogueManager.CallDialogue(recipeDialogue.ToList());
        return false;
    }
}
