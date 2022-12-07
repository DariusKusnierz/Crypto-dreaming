using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interaction : MonoBehaviour
{
    [SerializeField] bool canTalk = false;
    [SerializeField] bool isQuest = false;
    [SerializeField] GameObject answerPanel = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Interakcja z " + gameObject.name);
        if (canTalk)
            GetComponent<Dialogue>().StartDialogue();

        if (isQuest)
        {
            answerPanel.SetActive(true);
            answerPanel.GetComponentInChildren<TMP_InputField>().ActivateInputField();
            PlayerMovement.instance.enabled = false;
        }
    }
}
