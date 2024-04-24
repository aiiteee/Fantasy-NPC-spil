using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("NPC Conversation")]
    [SerializeField] private NPCConversation myConversation;

    public bool isInRange;
    public bool hasSpokenTo=false;
    public bool hasFinishedQuest = false;

    public bool checkMark1 = false;
    public bool checkMark2 = false;

    public PlayerMovement playerScript;
    public QuestManager questManager;
    

    public Animator animator;

    private void Awake()
    {
        isInRange = false;
        visualCue.SetActive(false);
    }

    public void Update()
    {
        if (isInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                ConversationManager.Instance.SetBool("hasSpokenTo",hasSpokenTo);
                ConversationManager.Instance.SetBool("finishedQuest", hasFinishedQuest);
                
                isInRange =false;
                playerScript.moveSpeed = 0f;
            }
        }
        else
        {
            visualCue.SetActive(false);
            
        }
    }

    public void HasSpokenTo()
    {
        hasSpokenTo = true;
    }

    public void CheckMark1_1mark()
    {
        checkMark1=true;
    }

    public void CheckMark1_2mark()
    {
        checkMark2 = true;
    }


    public void HasFinishedQuest1()
    {
        if(checkMark1 && checkMark2)
        {
            hasFinishedQuest=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    public void ResetSpeed()
    {
        playerScript.moveSpeed = 5f;
    }
}
