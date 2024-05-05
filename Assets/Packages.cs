using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packages : MonoBehaviour
{
    public bool canInteract;
    public GameObject interactCue;
    public GameObject choicesBjörn;
    public GameObject choicesRanus;

    public BranchSystem branchSystem;
    public DialogueTrigger dialogueTrigger;

    public void Update()
    {
        if (canInteract&&!dialogueTrigger.hasPacked)
        {
            interactCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                interactCue.SetActive(false);
                canInteract = false;

                if(branchSystem.björnPoints == 1)
                {
                    choicesBjörn.SetActive(true);
                }

                if(branchSystem.ranusPoints == 1)
                {
                    choicesRanus.SetActive(true);
                }

            }
        }
        else
        {
            interactCue.SetActive(false);
        }
    }

    public void HideOption()
    {
        choicesBjörn.SetActive(false);
        choicesRanus.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && dialogueTrigger.questBegun)
        {
            canInteract = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

}
