using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
    [SerializeField] GameObject messagePanel;
    [SerializeField] GameObject messageIcon;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!messageIcon.activeSelf)
                return;

            messagePanel.SetActive(!messagePanel.activeSelf);
        }
    }
}
