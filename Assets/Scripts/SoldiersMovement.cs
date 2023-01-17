using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldiersMovement : MonoBehaviour
{
    public Transform objectToMove;
    public Transform finishPoint;

    public Vector3 playerNewPosition;

    Image curtain;
    void Start()
    {
        curtain = SceneChanger.instance.curtain;
    }

    public void StartMoving()
    {
        StartCoroutine(MovingCoroutine());
    }

    IEnumerator MovingCoroutine()
    {
        while (objectToMove.localPosition.x <= finishPoint.localPosition.x)
        {
            Debug.LogWarning("Object:" + objectToMove.localPosition.x);
            Debug.LogWarning("Point:" + finishPoint.localPosition.x);
            objectToMove.localPosition += Vector3.right / 5;
            
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            curtain.color = new Color(0, 0, 0, alpha);
            alpha += 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
        PlayerMovement.instance.transform.position = playerNewPosition;
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            curtain.color = new Color(0, 0, 0, alpha);
            alpha -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
