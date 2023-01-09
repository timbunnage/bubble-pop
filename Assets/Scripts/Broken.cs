using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Broken : Item
{
    public int[] recipe = {0,0,0,0,0,0,0};

    public string[] firstDialogueList =
    {
        "Oh look, a tractor!\nIt seems to be broken.",
        "We need to fix it."
    };

    public string[] repeatDialogueList =
    {
        "fix it!"
    };

    public string[] collectedDialogueList =
    {
        "It's getting darker..."
    };

    private bool _investigated;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override bool Collect() {
        if (ReceipeCompleted())
        {
            DialogueManager.CallDialogue(collectedDialogueList.ToList());
        
            return base.Collect();
        }
        
        if (!_investigated)
        {
            DialogueManager.CallDialogue(firstDialogueList.ToList());
            _investigated = true;
            return false;
        }

        DialogueManager.CallDialogue(repeatDialogueList.ToList());
        return false;
    }

    // Check if the recipe has been completed
    private bool ReceipeCompleted()
    {
        return StoryManager.irisCollected         >= recipe[1] &&
               StoryManager.irisMetalCollected    >= recipe[2] &&
               StoryManager.tulipCollected        >= recipe[3] &&
               StoryManager.tulipMetalCollected   >= recipe[4] &&
               StoryManager.violetCollected       >= recipe[5] &&
               StoryManager.violetMetalCollected  >= recipe[6];
    }
}
