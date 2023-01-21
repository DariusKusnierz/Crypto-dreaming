using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class RowGear
{
    public List<TMP_Text> GearTexts = new List<TMP_Text>();
}

public class Enigma : MonoBehaviour
{
    public int column, row;
    public bool directionUpDown, directionLeftRight;
    public RectTransform selector;
    public List<string> answers = new List<string>();
    public int[][] gear = new int[4][];
    public char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    public List<RowGear> rowGears = new List<RowGear>();
    public List<Image> lights = new List<Image>();

    public Quest actualQuest;

    Color lightOn = new Color(1f, 0.11f, 0.11f);
    Color lightOff = new Color(0.6f, 0.14f, 0.14f);

    // Start is called before the first frame update
    void Start()
    {
        column = 1;
        row = 1;

        for(int i = 0; i < 4; i++)
        {
            gear[i] = new int[4];
            
            for (int j = 1; j < 4; j++)
                gear[i][j] = 1;
        }
            


    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeSelf) return;
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            directionLeftRight = false;
            if (column != 2)
                ChangeValue(true);
            else
                ChangeValue(false);
            return;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            directionLeftRight = true;
            if (column != 2)
                ChangeValue(true);
            else
                ChangeValue(false);
            return;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            directionUpDown = true;
            ChangeRow();
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            directionUpDown = false;
            ChangeRow();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeColumn(1);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeColumn(2);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeColumn(3);
            return;
        }
    }

    private void ChangeSelectorAnchors()
    {
        //selector change anchor and clear PosX PosY
        selector.anchorMin = new Vector2(column / 2f - 0.5f, Mathf.Abs(row - 3f) / 2f);
        selector.anchorMax = new Vector2(column / 2f - 0.5f, Mathf.Abs(row - 3f) / 2f);
        selector.anchoredPosition = Vector2.zero;
    }

    private void ChangeColumn(int columnNumber)
    {
        column = columnNumber;
        ChangeSelectorAnchors();
    }

    private void ChangeRow()
    {
        if (directionUpDown)
            row = Mathf.Clamp(--row, 1, 3);
        else
            row = Mathf.Clamp(++row, 1, 3);
        ChangeSelectorAnchors();
    }

    void ChangeValue(bool isNumeric)
    {
        //zmiana wartoœci zêbatki
        if (directionLeftRight)
        {
            gear[row][column]++;
            if (isNumeric && gear[row][column] > 9)
                gear[row][column] = 1;
            if (!isNumeric && gear[row][column] > 25)
                gear[row][column] = 0;
        }
        else
        {
            gear[row][column]--;
            if (isNumeric && gear[row][column] < 1)
                gear[row][column] = 9;
            if (!isNumeric && gear[row][column] < 1)
                gear[row][column] = 25;
        }

        if(isNumeric)
            rowGears[row].GearTexts[column].text = gear[row][column].ToString();
        else
            rowGears[row].GearTexts[column].text = alphabet[gear[row][column]].ToString();

        VerifyRow();
    }

    private void VerifyRow()
    {
        string rowText = "";
        for (int i = 1; i < 4; i++)
        {
            rowText += rowGears[row].GearTexts[i].text;
        }

        if (rowText.Equals(answers[row]))
        {
            lights[row].color = lightOn;
            VerifyCompletedQuest();
        }
        else
            lights[row].color = lightOff;

        
    }

    private void VerifyCompletedQuest()
    {
        if (lights[1].color == lightOn && lights[2].color == lightOn && lights[3].color == lightOn)
            actualQuest.isCompleted = true;
    }
}
