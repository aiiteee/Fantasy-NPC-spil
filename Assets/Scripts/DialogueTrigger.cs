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
    [SerializeField] private NPCConversation myThirdConversation;

    public bool isInRange;
    public bool hasSpokenTo = false;
    public bool finishedQuest = false;
    public bool questBegun = false;
    public bool chosenDifferentPerson;

    public bool checkMark1 = false;
    public bool checkMark2 = false;
    public bool secondConversation;
    public bool thirdConversation;
    public bool newText;
    public bool cantFinishYet = false;
    public bool hasPacked;


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
        if (checkMark1 && checkMark2)
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
                    ConversationManager.Instance.SetBool("hasPacked", hasPacked);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(myConversation);
                    ConversationManager.Instance.SetBool("hasSpokenTo", hasSpokenTo);
                    ConversationManager.Instance.SetBool("finishedQuest", finishedQuest);
                    ConversationManager.Instance.SetBool("questBegun", questBegun);
                    ConversationManager.Instance.SetBool("chosenDifferentPerson", chosenDifferentPerson);

                    
                }

                if(thirdConversation)
                {
                    ConversationManager.Instance.StartConversation(myThirdConversation);
                    ConversationManager.Instance.SetBool("finishedQuest", finishedQuest);
                }

                isInRange = false;
                playerScript.moveSpeed = 0f;
            }
        }
        else
        {
            visualCue.SetActive(false);

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


    public void QuestFinished()
    {
        finishedQuest = true;
    }

    public void HasSpokenTo()
    {
        hasSpokenTo = true;
    }

    public void CheckMark1_1mark()
    {
        checkMark1 = true;
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

    public void NextThirdConversation()
    {
        thirdConversation = true;
    }

    public void ChosenDifferentPerson()
    {
        chosenDifferentPerson = true;
    }

    public void oneMoreQuest()
    {
        finishedQuest = false;
        hasSpokenTo=false;
    }

    public void nextQuestText()
    {
        newText = true;
    }

    public void CanFinishYet()
    {
        if (questManager.currentAmount1 == questManager.goalAmount1)
        {
            cantFinishYet = true;
        }
    }

    public void HasPacked()
    {
        hasPacked = true;
    }
    
    public void ShopkeeperDone()
    {
        questManager.shopkeeperDone = true;
        if (questManager.situation1)
        {
            questManager.shopkeeperTeaTrigger.SetActive(false);
            questManager.shopkeeperSugarTrigger.SetActive(false);
        }
        if (questManager.situation2)
        {
            questManager.charlotteTrigger.SetActive(false);
        }
        if (questManager.situation3)
        {
            questManager.shopkeeperSugarTrigger.SetActive(false);
        }
        
        

    }

    public void SquireFinishedTalking()
    {
        questManager.squireFinished = true;
    }

    public void CharlotteFinishedTalking()
    {
        questManager.charlotteFinished = true;
    }
    
    

    public void ResetSpeed()
    {
        playerScript.moveSpeed = 5f;
    }

    public void StartSecondConversation()
    {
        ConversationManager.Instance.StartConversation(mySecondConversation);
    }
}
