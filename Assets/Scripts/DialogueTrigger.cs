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

    public PlayerMovement playerScript;
    

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
                ConversationManager.Instance.SetInt("characterLevel", 10);
                isInRange=false;
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

    public void ResetSpeed()
    {
        playerScript.moveSpeed = 4f;
    }
}
