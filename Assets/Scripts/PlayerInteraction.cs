using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerInteraction : MonoBehaviour
{
    GameObject objectOfInteraction;
    bool canInteract = false;

    void Update()
    {
        if (!canInteract) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canInteract = false;
            objectOfInteraction.GetComponent<Interaction>().Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Interaction>())
        {
            objectOfInteraction = other.gameObject;
            canInteract = true;
        }
    }
}
