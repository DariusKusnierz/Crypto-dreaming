using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigma : MonoBehaviour
{
    public int column, row;
    public bool directionUpDown, directionLeftRight;
    public RectTransform selector;
    public List<string> answers = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        column = 1;
        row = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeSelf) return;
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            directionLeftRight = false;
            ChangeValue();
            return;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            directionLeftRight = true;
            ChangeValue();
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
        selector.anchorMin = new Vector2(column / 2f - 0.5f, row / 2f - 0.5f);
        selector.anchorMax = new Vector2(column / 2f - 0.5f, row / 2f - 0.5f);
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
            row++;
        else
            row--;
        ChangeSelectorAnchors();
    }

    void ChangeValue()
    {
        //zmiana wartoœci zêbatki
        VerifyRow();
    }

    private void VerifyRow()
    {

        throw new NotImplementedException();
    }
}
