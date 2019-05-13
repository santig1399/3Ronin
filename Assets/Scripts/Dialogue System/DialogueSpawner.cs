using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpawner : MonoBehaviour
{

    public Dialogue dialogue;
    private bool wasUsed = false;
    public GameObject twinDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && !wasUsed) {
            wasUsed = true;
            if (twinDialog != null) {
                twinDialog.SetActive(false);
            }
            
            FindObjectOfType<DialogueManager>().Index = 0;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
