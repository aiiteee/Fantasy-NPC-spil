using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip clip;
    public float volume = 1;
    public bool canPickUp=false;
    public QuestManager questManager;
    public DialogueTrigger dialogueTrigger;
    public GameObject pickUpcue;

    public UnityEvent triggerEvent;


    // Update is called once per frame
    private void Update()
    {
        if(canPickUp)
        {
            pickUpcue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)&& dialogueTrigger.newText)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position, volume);
                Destroy(gameObject);
                questManager.currentAmount1 += 1;
                dialogueTrigger.CanFinishYet();
            }

            if (Input.GetKeyDown(KeyCode.F) && questManager.questFourBegun)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position, volume);
                Destroy(gameObject);
                questManager.currentAmount1 += 1;
            }

            if (!dialogueTrigger.newText &&!questManager.questFourBegun)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    AudioSource.PlayClipAtPoint(clip, transform.position, volume);
                    Destroy(gameObject);
                    questManager.UpdateQuest3part2();
                    questManager.swordFound = true;
                    triggerEvent.Invoke();
                }
                
            }

        }
        else
        {
            pickUpcue.SetActive(false);
        }
    }
    

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&dialogueTrigger.questBegun)
        {
            canPickUp = true;
        }

        if (other.CompareTag("Player") && questManager.questThreeBegun)
        {
            canPickUp = true;
        }

        if (other.CompareTag("Player") && questManager.pickUpSword)
        {
            canPickUp = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }
}