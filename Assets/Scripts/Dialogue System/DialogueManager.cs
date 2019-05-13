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
    private Dialogue dialog;
    public int Index { get => index; set => index = value; }
    public int ind;


    public void StartDialogue(Dialogue dialogue)
    {   
        if (dialogue != null) {
            FindObjectOfType<AudioManager>().Play("Ghost");
            this.dialog = dialogue;
            this.sentences = dialogue.dialogSentences;
            //Debug.Log("Dialogu: "+dialogue.name);
            dialogueUi.SetActive(true);
            StartCoroutine(Type());
            inventory.SetActive(false);

            // FindObjectOfType<Movement>().speed =0;

            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy e in enemies)
            {
                e.speed = 0f;
            }
            FindObjectOfType<Movement>().speed = 0;
            
        }
    }
    private void Update()
    {
        ind = index;
        if (sentences != null) {
            if (textDisplay.text == sentences[Index])
            {
                if (dialog.dialogName == "Intro") {
                    FindObjectOfType<AudioManager>().Stop("AmbientMusic");
                }
                if (dialog.dialogName == "Intro" && index == 7)
                {
                    FindObjectOfType<AudioManager>().Play("Laugh");

                }
                else if (dialog.dialogName == "Intro" && index > 7) {
                    FindObjectOfType<AudioManager>().Play("AmbientMusic");
                    FindObjectOfType<AudioManager>().Stop("Gost");
                }

                continueButton.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)) {
                    NewSentence();
                }
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

            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy e in enemies)
            {
                e.speed = 2.41f;
            }
            FindObjectOfType<Movement>().speed = 5;
            FindObjectOfType<AudioManager>().Stop("Ghost");
            
        }
    }
}
