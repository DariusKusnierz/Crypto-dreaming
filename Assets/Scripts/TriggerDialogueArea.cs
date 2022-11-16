using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerDialogueArea : MonoBehaviour
{
    [SerializeField] Dialogue dialogueToStart;

    PlayerMovement.Direction actualDirection;
    PlayerMovement.Direction targetDirection;
    private bool isMovingBack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
            return;

        dialogueToStart.StartDialogue();

        SpecifyOutDirection();
        StartCoroutine(MoveBackCoroutine());
    }

    IEnumerator MoveBackCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        PlayerMovement.instance.enabled = false;
        isMovingBack = true;

        while (isMovingBack)
        {
            PlayerMovement.instance.MoveToDirection(targetDirection);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isMovingBack = false;
    }

    void SpecifyOutDirection()
    {
        actualDirection = PlayerMovement.instance.playerDirection;

        if (actualDirection == PlayerMovement.Direction.Up)
            targetDirection = PlayerMovement.Direction.Down;
        else if (actualDirection == PlayerMovement.Direction.Down)
            targetDirection = PlayerMovement.Direction.Up;
        else if (actualDirection == PlayerMovement.Direction.Left)
            targetDirection = PlayerMovement.Direction.Right;
        else if (actualDirection == PlayerMovement.Direction.Right)
            targetDirection = PlayerMovement.Direction.Left;
    }
}
