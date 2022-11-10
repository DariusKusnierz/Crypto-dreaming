using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialoguePath
{
    public List<string> dialogueLine = new List<string>();
    public bool isConnectedWithQuest = false;
    public Quest actualQuest;
}

[RequireComponent(typeof(Interaction))]
public class Dialogue : MonoBehaviour
{
    public List<DialoguePath> dialoguePath = new List<DialoguePath>();
    [SerializeField] public bool isChangingScene = false;



    public void StartDialogue()
    {
        int pathIterator;

        for(pathIterator = 0; pathIterator < dialoguePath.Count; pathIterator++)
        {
            if (!dialoguePath[pathIterator].isConnectedWithQuest)
                break;

            if (dialoguePath[pathIterator].actualQuest.isCompleted)
                continue;
            else
                break;
        }

        DialoguesSystem.instance.LoadDialogue(gameObject, dialoguePath[pathIterator].dialogueLine, isChangingScene);
    }
}
