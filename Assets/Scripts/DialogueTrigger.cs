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
    [SerializeField] private NPCConversation mySecondConversation;

    public bool isInRange;
    public bool hasSpokenTo=false;
    public bool finishedQuest = false;
    public bool questBegun=false;

    public bool checkMark1 = false;
    public bool checkMark2 = false;
    public bool secondConversation;


    public GameObject firstMarkY;
    public GameObject firstMarkX;
    public GameObject returnToQuest;

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
        if(checkMark1&&checkMark2)
        {
            finishedQuest = true;
            
        }
             
        if (isInRange)
        {
            visualCue.SetActive(true);
            //firstMarkY.SetActive(true);
            //firstMarkX.SetActive(false);
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                
                if (secondConversation)
                {
                    ConversationManager.Instance.StartConversation(mySecondConversation);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(myConversation);
                    ConversationManager.Instance.SetBool("hasSpokenTo", hasSpokenTo);
                    ConversationManager.Instance.SetBool("finishedQuest", finishedQuest);
                    ConversationManager.Instance.SetBool("questBegun", questBegun);
                }

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

    public void QuestHasBegun()
    {
        questBegun = true;
    }

    public void NextSecondConversation()
    {
        secondConversation = true;
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
