using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text textDisplay;
    private string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject inventory;
    public GameObject dialogueUi;
    public GameObject initialSplashArt;
    //public Dialogue dialogue; 

    public GameObject continueButton;

    public int Index { get => index; set => index = value; }

    public void StartDialogue(Dialogue dialogue)
    {   
        if (dialogue != null) {
            this.sentences = dialogue.dialogSentences;
            //Debug.Log("Dialogu: "+dialogue.name);
            dialogueUi.SetActive(true);
            StartCoroutine(Type());
            inventory.SetActive(false);
            FindObjectOfType<Movement>().speed = 0;
        }
    }
    private void Update()
    {
        if (sentences != null) {
            if (textDisplay.text == sentences[Index])
            {
                continueButton.SetActive(true);
            }
        }
        
    }

    IEnumerator Type() {
       
        foreach (char letter in sentences[Index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
    }

    public void NewSentence() {

        continueButton.SetActive(false);

        if (Index < sentences.Length - 1)
        {
            Index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else {
            textDisplay.text = "";
            dialogueUi.SetActive(false);
            initialSplashArt.SetActive(false);
            inventory.SetActive(true);
            continueButton.SetActive(false);
            FindObjectOfType<Movement>().speed = 5;
        }
    }
}
