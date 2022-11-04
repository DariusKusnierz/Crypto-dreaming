using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] List<Sprite> movementSprite = new List<Sprite>();
    [SerializeField] Collider2D interractionCollider;

    enum Direction {Up, Down, Left, Right};

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * 0.25f * speed * Time.deltaTime;
            changeDirection(Direction.Up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * 0.25f * speed * Time.deltaTime;
            changeDirection(Direction.Down);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 0.25f * speed * Time.deltaTime;
            changeDirection(Direction.Left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 0.25f * speed * Time.deltaTime;
            changeDirection(Direction.Right);
        }
    }

    void changeDirection(Direction actualDirection)
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
