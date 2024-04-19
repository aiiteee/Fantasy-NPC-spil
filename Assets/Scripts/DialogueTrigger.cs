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

    //public PlayerMovement script;

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
                isInRange=false;
                //script.moveSpeed = 0f;
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
        //script.moveSpeed = 5f;
    }
}
