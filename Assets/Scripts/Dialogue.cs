using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] public List<string> dialogueLine = new List<string>();
    [SerializeField] public bool isChangingScene = false;

    public void StartDialogue()
    {
        DialoguesSystem.instance.LoadDialogue(gameObject, dialogueLine, isChangingScene);
    }
}
