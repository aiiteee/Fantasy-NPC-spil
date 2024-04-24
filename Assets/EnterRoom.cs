using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRoom : MonoBehaviour
{
    public GameObject leaveOrEnterRoom;
    public string nextScene;
    public bool isInRange;

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            leaveOrEnterRoom.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {

                SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
            }
            
        }
        else
        {
            leaveOrEnterRoom.SetActive(false);

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
