using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialoguesSystem : MonoBehaviour
{
    #region Singleton

    public static DialoguesSystem instance;
    
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
    }


    #endregion

    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] bool canChangeScene = false;
    [SerializeField] GameObject talkingIcon;
    [SerializeField] GameObject interlocutor;
    [SerializeField] GameObject objectToActive;

    List<string> dialogueLine = new List<string>();
    int dialogueIndex = 0;

    void Start()
    {
        dialogueText = dialoguePanel.GetComponentInChildren<TMP_Text>();
        dialogueText.text = "...";
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialoguePanel.active == true)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                loadNextDialogueLine();
            }
        }
    }

    void activeTalkingIcon()
    {
        talkingIcon.transform.position = interlocutor.transform.position + new Vector3(0,0.5f,-5f);
        talkingIcon.SetActive(true);
    }

    void deactiveTalkingIcon()
    {
        Debug.LogWarning("Rozpoczêcie deaktywacji");
        talkingIcon.SetActive(false);
    }

    void loadNextDialogueLine()
    {
        dialogueIndex = dialogueIndex + 1;

        if(dialogueIndex >= dialogueLine.Count)
        {
            if(objectToActive != null)
                objectToActive.SetActive(true);

            dialoguePanel.SetActive(false);
            dialogueIndex = 0;
            deactiveTalkingIcon();
            interlocutor.GetComponent<Dialogue>().StartPostCompleteActivity();
            PlayerMovement.instance.enabled = true;

            if (canChangeScene)
                SceneChanger.instance.launchFadeIn();
            
            return;
        }

        dialogueText.text = dialogueLine[dialogueIndex].ToString();
    }

    public void LoadDialogue(GameObject whoTalk, List<string> dialogue, bool changeScene, GameObject activate)
    {
        interlocutor = whoTalk;
        dialogueLine = dialogue;
        canChangeScene = changeScene;
        objectToActive = activate;

        activeTalkingIcon();
        dialogueText.text = dialogueLine[0].ToString();
        gameObject.SetActive(true);
    }
}
