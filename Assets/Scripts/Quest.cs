using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    enum QuestType {Cezar, Vigener, ADFGVX, Playfair, Enigma}

    [SerializeField] string questName;
    [SerializeField] QuestType type;
    [SerializeField] string answer;
    [SerializeField] GameObject playerAnswerPanel;
    [SerializeField] TMP_InputField playerAnswer;
    [SerializeField] Dialogue dialogueToChangeWhenFinished;
    [SerializeField] bool canChangeScene = false;

    bool isCompleted = false;

    private void Start()
    {
        playerAnswer = playerAnswerPanel.GetComponentInChildren<TMP_InputField>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerAnswerPanel.SetActive(false);
            PlayerMovement.instance.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckPlayerAnswer();
        }
    }

    void CheckPlayerAnswer()
    {
        
        Debug.Log("Odp gracza: " + playerAnswer.text);
        Debug.Log("Odp poprawna: " + answer.ToString());


        if (Equals(playerAnswer.text.ToLower().Trim('\r', '\n').Trim(), "ave cezar"))
            FinishQuest();
        else
        {
            playerAnswer.GetComponentsInChildren<TMP_Text>()[1].color = Color.red;
            Debug.Log("Z≥a odpowiedü");
        }

    }

    void FinishQuest()
    {
        isCompleted = true;

        playerAnswer.GetComponentsInChildren<TMP_Text>()[1].color = Color.green;

        Debug.Log("Dobra odpowiedü");
    }

    public void ClearColor()
    {
        Color newColor;
        ColorUtility.TryParseHtmlString("#221C1C", out newColor);
        playerAnswer.GetComponentsInChildren<TMP_Text>()[1].color = newColor;
    }
}
