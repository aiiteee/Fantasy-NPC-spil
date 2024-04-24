using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public GameObject leaveRoomUI;
    public GameObject newPlayer;
    public GameObject oldPlayer;
    public GameObject doorTriger;


    public bool isInRange=false;
    public bool isInside = false;
    public string sceneName;
    public string currentScene;
    
    
    
    void Update()
    {
        if (isInRange)
        {
            leaveRoomUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)&& !isInside)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
                //oldPlayer.SetActive(false);
                newPlayer.SetActive(true);
                isInside=true;
                
            }
            if(Input.GetKeyDown(KeyCode.F) && isInside)
            {
                SceneManager.UnloadSceneAsync("Brewery", UnloadSceneOptions.None);
                isInside = false;
                //oldPlayer.SetActive(true);
                newPlayer.SetActive(false);
                doorTriger.SetActive(false);
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
