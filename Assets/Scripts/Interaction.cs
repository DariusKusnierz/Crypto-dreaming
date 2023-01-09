using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Interaction : MonoBehaviour
{
    [SerializeField] bool canTalk = false;
    [SerializeField] bool isQuest = false;
    [SerializeField] GameObject answerPanel = null;

    public UnityEvent onInteracted;
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

        onInteracted.Invoke();
    }
}
