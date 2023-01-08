using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    List<string> dialogue;
    int currentDialogueIndex;

    public GameObject dialogueTextObject;
    public GameObject anyKeyTextObject;
    private TMP_Text myText;
    private TMP_Text anyKeyText;

    public bool active;

    float letterTimer;

    // Start is called before the first frame update
    void Start()
    {
        myText = dialogueTextObject.GetComponent<TMP_Text>();
        Debug.Log(myText.text);

        anyKeyText = anyKeyTextObject.GetComponent<TMP_Text>();
        
        // gameObject.SetActive(false);
        SetDialogueActive(false);

        active = false;

  
        letterTimer = 0f;

        dialogue = new List<string>();
        currentDialogueIndex = 0;
    }

    void SetDialogueActive(bool isActive) {
        dialogueTextObject.SetActive(isActive);
        anyKeyTextObject.SetActive(isActive);
    }

    public void setDialogue(List<string> Idialogue) {
        currentDialogueIndex = 0;

        dialogue = Idialogue;

        active = true;
        // gameObject.SetActive(true);
        SetDialogueActive(true);

        letterTimer = 0f;

        myText.text = "";
    }

    float lastDeltaTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime > 0) {
            lastDeltaTime = Time.deltaTime;
        }

        if (active) {
            float timeChange = lastDeltaTime;
            letterTimer = letterTimer - timeChange;
            if (dialogue[currentDialogueIndex].Length > 0) {
                if (letterTimer <= 0) {
                    letterTimer = letterTimer + 0.02f;
                    myText.text = myText.text + dialogue[currentDialogueIndex][0];
                    dialogue[currentDialogueIndex] = dialogue[currentDialogueIndex].Substring(1);
                }

                if (Input.inputString.Length > 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                // if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                // if (Input.anyKeyDown) {
                    myText.text = myText.text + dialogue[currentDialogueIndex];
                    dialogue[currentDialogueIndex] = "";
                }

                anyKeyText.text = "";
            } else {
                anyKeyText.text = "Press any key...";
                if (Input.inputString.Length > 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                // if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                // if (Input.anyKeyDown) {
                    if (currentDialogueIndex < dialogue.Count - 1) {
                        letterTimer = 0;
                        currentDialogueIndex = currentDialogueIndex + 1;
                    } else {
                        active = false;
                        // gameObject.SetActive(false);
                        SetDialogueActive(false);
                    }
                    myText.text = "";
                }
            }
        }
    }
}
