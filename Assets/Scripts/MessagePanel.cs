using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
    [SerializeField] List<GameObject> messagePanel;
    [SerializeField] List<GameObject> messageIcon;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!messageIcon[0].activeSelf)
                return;

            messagePanel[0].SetActive(!messagePanel[0].activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!messageIcon[1].activeSelf)
                return;

            messagePanel[1].SetActive(!messagePanel[1].activeSelf);
        }
    }
}
