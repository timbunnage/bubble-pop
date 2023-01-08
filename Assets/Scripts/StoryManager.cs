using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static int StoryProgress = 0;
    public static string[] mainDialogue;

    public static int GrassDestroyed = 0;

    public GameObject playerObject;

    static GameObject _dm;
    public static GameObject dialogueManagerObject
    { get { return _dm ? _dm : (_dm = GameObject.Find("DialogueManager")); } }
    
    // Start is called before the first frame update
    void Start()
    {
        // split string with \n
        mainDialogue = new[] {"Why hello there.\nWhat are you doing here.\nYou know this place is dangerous, right?",
                            "Didn't I tell you to leave?\nYou are not welcome here.\nRun away, child."};

        _dm = GameObject.Find("DialogueManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void IncrementStory()
    {
        print("Story progressed");
        StoryProgress++;
        
        // Speed bubble stuff here

        List<string> currDialogue = new List<string>();
        foreach (string s in mainDialogue[ (StoryProgress-1)%2 ].Split("\n")) {
            currDialogue.Add(s);
        }

        // foreach( var x in currDialogue) { Debug.Log( x.ToString()); }

        // begin current dialogue
        dialogueManagerObject.GetComponent<DialogueManager>().setDialogue(currDialogue);
    }
}
