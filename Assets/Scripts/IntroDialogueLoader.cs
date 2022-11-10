using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogueLoader : MonoBehaviour
{
    void Start()
    {
        startDialogue();
    }

    void startDialogue()
    {
        DialoguesSystem.instance.LoadDialogue(gameObject, GetComponent<Dialogue>().dialoguePath[0].dialogueLine, GetComponent<Dialogue>().isChangingScene);
    }
}
