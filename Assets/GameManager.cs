using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menuBars;
    public GameObject questsWindow;
    public GameObject map;
    public GameObject inventory;
    public GameObject activeQuests;
    public GameObject icons;

    public GameObject doorTrigger;

    public GameObject cutScene;

    void Awake()
    {
        cutScene.SetActive(true);
    }
    
    /*public void ShowDoorTrigger()
    {
        showDoorTrigger.SetActive(true);
    }*/

    public void ShowMenuBars()
    {
        menuBars.SetActive(true);
        icons.SetActive(false);
        Time.timeScale=0;
    }

    public void HideMenuBars()
    {
        menuBars.SetActive(false);
        icons.SetActive(true);
        Time.timeScale=1;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
