using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKills : MonoBehaviour
{
    public int kills;
    public int bossKills;
    public Dialogue firstBloodDialogue;
    public Dialogue endDialogue;
    public bool firstBlood = false;
    public bool end =false;

    void Update()
    {
        if (kills >0 && firstBlood == false) {
            FindObjectOfType<DialogueManager>().Index = 0;
            FindObjectOfType<DialogueManager>().StartDialogue(firstBloodDialogue);
            firstBlood = true;
        }
        if (bossKills == 2 && end ==false) {
            FindObjectOfType<DialogueManager>().Index = 0;
            FindObjectOfType<DialogueManager>().StartDialogue(endDialogue);
            end = true;
        }
    }
}
