using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public GameObject leaveRoomUI;
    


    public bool isInRange=false;
    
    public string currentScene;

    
    
    void Update()
    {


        leaveRoomUI.SetActive(true);
        if (isInRange)
        {
            
            if(Input.GetKeyDown(KeyCode.F))
            {
                
                SceneManager.UnloadSceneAsync("Brewery");
                
                
            }
        }
        else
        {
            leaveRoomUI.SetActive(false);

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
