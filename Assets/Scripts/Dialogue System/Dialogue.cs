using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Dialogue", menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    public string nameOfDialogue;
    public string npcName;
    public string[] dialogSentences;
}
