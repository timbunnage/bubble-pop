using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static int StoryProgress = 0;
    public static readonly string[] DialogueList =
    {
        "Why hello there.\nWhat are you doing here.\nYou know this place is dangerous, right?",
        "Didn't I tell you to leave?\nYou are not welcome here.\nRun away, child."
    };

    public static int GrassDestroyed = 0;
    
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

    public void IncrementStory()
    {
        print("Story progressed");
        
        var currentDialogue = DialogueList[StoryProgress].Split("\n").ToList();

        // begin current dialogue
        _dialogueManager.CallDialogue(currentDialogue);
        
        StoryProgress++;
    }
}
