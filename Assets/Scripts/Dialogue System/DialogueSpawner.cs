using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpawner : MonoBehaviour
{

    public Dialogue dialogue;
    private bool wasUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && !wasUsed) {
            wasUsed = true;
            FindObjectOfType<DialogueManager>().Index = 0;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
