using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] string questName;
    [SerializeField] enum questType {Cezar, Vigener, ADFGVX, Playfair, Enigma}
    [SerializeField] string answer;
    [SerializeField] string playerAnswer;
    [SerializeField] Dialogue dialogueToChangeWhenFinished;
    [SerializeField] bool canChangeScene = false;


    void checkPlayerAnswer()
    {
        if (playerAnswer == answer)
            finishQuest();
        else
            PlayerPrefs.SetInt("Wrong", 1);

    }

    void finishQuest()
    {

    }
}
