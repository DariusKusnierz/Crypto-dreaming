using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerInteraction : MonoBehaviour
{
    Interaction objectOfInteraction;
    bool canInteract = false;

    void Update()
    {
        if (!canInteract) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canInteract = false;
            objectOfInteraction.Interact();

            if(objectOfInteraction.canTalk || objectOfInteraction.isQuest)
                PlayerMovement.instance.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Interaction>())
        {
            objectOfInteraction = other.GetComponent<Interaction>();
            canInteract = true;
        }
    }
}
