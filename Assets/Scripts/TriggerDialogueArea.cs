using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerDialogueArea : MonoBehaviour
{
    [SerializeField] Dialogue dialogueToStart;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
            return;

        dialogueToStart.StartDialogue();
    }

}
