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
        DialoguesSystem.instance.LoadDialogue(gameObject, GetComponent<Dialogue>().dialogueLine, GetComponent<Dialogue>().isChangingScene);
    }
}
