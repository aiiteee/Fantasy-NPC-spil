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

    public GameObject lastText;
    public GameObject finishQuestFirst;

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            leaveOrEnterRoom.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (enterBrewery)
                {
                    SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
                }

                if(enterHome&&dialogueTrigger.finishedQuest)
                {
                    lastText.SetActive(true);
                }

                if (enterHome && !dialogueTrigger.finishedQuest)
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


  
}
