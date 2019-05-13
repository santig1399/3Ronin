using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Dialogue", menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    public string dialogName;
    public string[] dialogSentences;
}
