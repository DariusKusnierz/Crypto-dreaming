using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public GameObject menuPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (menuPanel.activeSelf)
            {
                menuPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                menuPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
