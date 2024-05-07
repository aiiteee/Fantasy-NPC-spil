using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRoom : MonoBehaviour
{
    public GameObject leaveOrEnterRoom;
    public string nextScene;
    public bool isInRange;
    public bool enterBrewery;
    public bool enterHome;

    public DialogueTrigger dialogueTrigger;
    public QuestManager questManager;

    public GameObject lastText;
    public GameObject finishQuestFirst;
    public GameObject heroEndingText;
    public GameObject villainEndingText;
    

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            leaveOrEnterRoom.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                

                if(enterHome&&questManager.canGoHome)
                {
                    lastText.SetActive(true);
                    if (questManager.heroEnding)
                    {
                        heroEndingText.SetActive(true);
                    }
                    if (questManager.villainEnding)
                    {
                        villainEndingText.SetActive(true);
                    }
                }

                if (enterHome && !questManager.canGoHome)
                {
                    finishQuestFirst.SetActive(true);
                }
                
            }
            
        }
        else
        {
            leaveOrEnterRoom.SetActive(false);
            finishQuestFirst.SetActive(false);
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

    public void NextDay()
    {
        SceneManager.LoadScene("Day 1");
    }


  
}
