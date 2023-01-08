using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static int StoryProgress = 0;
    public string[] mainDialogue;

    public static int GrassDestroyed = 0;

    public GameObject playerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void IncrementStory()
    {
        print("NEW STORY");
        StoryProgress++;
        
        // Speed bubble stuff here
    }
}
