using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton
    public static PlayerMovement instance;
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    #endregion


    [SerializeField] float speed = 0.5f;
    [SerializeField] List<Sprite> movementSprite = new List<Sprite>();
    [SerializeField] Collider2D interractionCollider;

    public enum Direction {Up, Down, Left, Right};

    public Direction playerDirection;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerDirection = Direction.Up;

            MoveToDirection(playerDirection);
            ChangeDirection(playerDirection);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerDirection = Direction.Down;

            MoveToDirection(playerDirection);
            ChangeDirection(playerDirection);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerDirection = Direction.Left;

            MoveToDirection(playerDirection);
            ChangeDirection(playerDirection);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerDirection = Direction.Right;

            MoveToDirection(playerDirection);
            ChangeDirection(playerDirection);
        }
    }

    public void MoveToDirection(Direction actualDirection)
    {
        Vector3 movementVector = Vector3.zero;

        if(actualDirection == Direction.Up) 
            movementVector = Vector3.up;
        else if(actualDirection == Direction.Down)
            movementVector = Vector3.down;
        else if (actualDirection == Direction.Left)
            movementVector = Vector3.left;
        else if (actualDirection == Direction.Right)
            movementVector = Vector3.right;

        transform.position += 0.25f * speed * Time.deltaTime * movementVector;
    }

    void ChangeDirection(Direction actualDirection)
    {
        GetComponent<SpriteRenderer>().sprite = movementSprite[((int)actualDirection)];
        changeColliderOffset(actualDirection);
    }

    void changeColliderOffset(Direction actualDirection)
    {
        if (actualDirection == Direction.Up)
            interractionCollider.offset = new Vector2(0, 0.56f);
        else if (actualDirection == Direction.Down)
            interractionCollider.offset = new Vector2(0, -0.56f);
        else if (actualDirection == Direction.Left)
            interractionCollider.offset = new Vector2(-0.48f, 0);
        else if (actualDirection == Direction.Right)
            interractionCollider.offset = new Vector2(0.48f, 0);
    }
}
