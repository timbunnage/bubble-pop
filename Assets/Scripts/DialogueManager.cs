using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject canvasObject;
    public bool active;

    public float characterDelay = 0.2f; // Time it takes for a character to appear in seconds
    public float lineDelay = 5f; // Time it takes for line to auto progress
    
    private TMP_Text _textObject;
    
    private List<string> _dialogueList;
    private int _dialogueProgress;

    private float _letterTimer;
    private float _lineTimer;

    // Start is called before the first frame update
    private void Start()
    {
        _textObject = canvasObject.GetComponent<TMP_Text>();
        canvasObject.SetActive(false);
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (!active) return;

        if (_dialogueList[_dialogueProgress].Length == 0)
        {
            _lineTimer -= Time.deltaTime;
            
            if (_lineTimer > 0) return;
            
            ProgressDialogue();
        }
        
        _letterTimer -= Time.deltaTime;

        if (_letterTimer > 0) return;
        
        _textObject.text += _dialogueList[_dialogueProgress][0]; // Add one character
        _dialogueList[_dialogueProgress] = _dialogueList[_dialogueProgress][1..];
                
        _letterTimer += characterDelay;
    }

    public void ProgressDialogue()
    {
        if (!active) return;
        
        // Add rest of line
        if (_dialogueList[_dialogueProgress].Length > 0)
        {
            _textObject.text += _dialogueList[_dialogueProgress];
            _dialogueList[_dialogueProgress] = "";
            return;
        }
        
        // Progress to next line
        if (_dialogueProgress < _dialogueList.Count - 1) {
            _letterTimer = 0;
            _dialogueProgress++;
        } else {
            active = false;
            canvasObject.SetActive(false);
        }
        _textObject.text = "";
        
        _lineTimer += lineDelay;
    }
    
    public void CallDialogue(List<string> inputDialogue) {
        _dialogueList = inputDialogue;
        
        _dialogueProgress = 0;
        _letterTimer = characterDelay;
        _lineTimer = lineDelay;
        _textObject.text = "";
        
        active = true;
        canvasObject.SetActive(true);
    }
}
