using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    enum QuestType {Cezar, Vigener, ADFGVX, Playfair, Enigma}

    [SerializeField] string questName;
    [SerializeField] QuestType type;
    [SerializeField] string answer;
    [SerializeField] GameObject playerAnswerPanel;
    [SerializeField] TMP_InputField playerAnswer;
    [SerializeField] Dialogue dialogueToChangeWhenFinished;
    public bool canChangeScene = false;

    public bool isCompleted = false;

    public UnityEvent OnCompleted;

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


        if (Equals(playerAnswer.text.ToLower().Trim('\r', '\n').Trim(), answer))
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
        OnCompleted?.Invoke();
        Debug.Log("Dobra odpowiedü");
    }

    public void ClearColor()
    {
        Color newColor;
        ColorUtility.TryParseHtmlString("#221C1C", out newColor);
        playerAnswer.GetComponentsInChildren<TMP_Text>()[1].color = newColor;
    }

    
    public void CheckNumberTyping()
    {
        Debug.Log("Sprawdzam czy jest liczba");
        var regex = "[0-9]";
        if (Regex.IsMatch(playerAnswer.text, regex))
        {
            Debug.Log("LICZBA!");
            playerAnswer.text = playerAnswer.text.Remove(playerAnswer.text.Length - 1);
        }
    }

    public void SetComplete(bool completed)
    {
        isCompleted = completed;
    }
}
