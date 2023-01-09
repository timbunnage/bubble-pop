using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Broken : Item
{


    public int[] recipe = {0,0,0,0,0,0,0};

    public string[] dialogueList =
    {
        "Oh look, a tractor!\nIt seems to be broken.",
        "We need to fix it."
    };

    public string[] blackScreenDialogue =
    {
        "It's getting darker..."
    };
    private GameObject _blackScreen;

    int timesCollected = 0;

    private StoryManager _storyManager; 
    private DialogueManager _dialogueManager; 
    

    // Start is called before the first frame update
    void Start()
    {
        _storyManager = FindObjectOfType<StoryManager>();
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _blackScreen = GameObject.Find("BlackScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Collect() {
        // recipe not yet completed
        if (!ReceipeCompleted()) 
                {
                    // SHOW RECIPE SOMEHOW
                    var currentDialogue = dialogueList[timesCollected].Split("\n").ToList();
                    _dialogueManager.CallDialogue(currentDialogue);
                    timesCollected = Mathf.Min(timesCollected + 1, dialogueList.Length-1);      // repeat calling the last line of dialogue
                    return false;
                }
        
       // fade black screen
       StartCoroutine(FadeToBlack());
        var d = blackScreenDialogue[0].Split("\n").ToList();
        _dialogueManager.CallDialogue(d);
        

        if (!base.Collect()) return false;

        
        return true;
    }

    // Check if the recipe has been completed
    bool ReceipeCompleted() {
        if (_storyManager.irisCollected         >= recipe[1] &&
            _storyManager.irisMetalCollected    >= recipe[2] &&
            _storyManager.tulipCollected        >= recipe[3] &&
            _storyManager.tulipMetalCollected   >= recipe[4] &&
            _storyManager.violetCollected       >= recipe[5] &&
            _storyManager.violetMetalCollected  >= recipe[6]    )  
            { 
                return true;
            }
        return false;
    }

    IEnumerator FadeToBlack()
    {
        // Color c = _blackScreen.GetComponent<CanvasRenderer>()
        Color c = _blackScreen.GetComponent<CanvasRenderer>() .GetColor();
        Debug.Log(c);
        // fade out
        // for (float alpha = 0f; alpha <= 1f; alpha += 0.1f)
        for (int alpha = 0; alpha <= 255; alpha += 15)
        {
            c.a = alpha;
            _blackScreen.GetComponent<CanvasRenderer>().SetColor(c);
            Debug.Log(alpha);
            yield return new WaitForSeconds(.1f);
        }
        Debug.Log(c);
        // fade in
        // for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        for (int alpha = 255; alpha >= 0; alpha -= 15)
        {
            c.a = alpha;
            _blackScreen.GetComponent<CanvasRenderer>().SetColor(c);
            Debug.Log(alpha);
            yield return new WaitForSeconds(.1f);
        }
        Debug.Log(c);
    }

}
