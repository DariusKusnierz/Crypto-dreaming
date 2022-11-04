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

    private void Start()
    {
        playerAnswer = playerAnswerPanel.GetComponentInChildren<TMP_InputField>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            playerAnswerPanel.SetActive(false);

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            CheckPlayerAnswer();
    }

    void CheckPlayerAnswer()
    {
        
        Debug.Log("Odp gracza: " + playerAnswer.text);
        Debug.Log("Odp poprawna: " + answer.ToString());


        if (Equals(playerAnswer.text.ToLower().Trim('\r', '\n').Trim(), "ave cezar"))
            FinishQuest();
        else
            Debug.Log("Z≥a odpowiedü");

    }

    void FinishQuest()
    {
        Debug.Log("Dobra odpowiedü");
    }
}
