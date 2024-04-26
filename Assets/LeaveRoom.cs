using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveRoom : MonoBehaviour
{
    public GameObject leaveRoomUI;
    public bool isInRange = false;
    public string sceneName;


    [SerializeField] Transform posToGo;


    void Update()
    {
        if (isInRange)
        {
            leaveRoomUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && SceneManager.GetSceneByName(sceneName).isLoaded);
            {
                SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
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
