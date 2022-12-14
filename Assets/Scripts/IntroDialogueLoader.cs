using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogueLoader : MonoBehaviour
{
    Dialogue dialogue;

    void Start()
    {
        dialogue = GetComponent<Dialogue>();
        StartDialogue();
    }

    void StartDialogue()
    {
        DialoguesSystem.instance.LoadDialogue(gameObject, dialogue.dialoguePath[0].dialogueLine, dialogue.isChangingScene, dialogue.dialoguePath[0].objectToActivate);
    }
}
