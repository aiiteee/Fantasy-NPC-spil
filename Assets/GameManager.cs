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

    public GameObject riddleNote;

    public bool isOpen;

    public QuestManager questManager;

    void Awake()
    {
        cutScene.SetActive(true);
    }
    
    

    public void Update()
    {
        if (!isOpen&&questManager.pickUpSword)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                riddleNote.SetActive(true);
                isOpen = true;
                Time.timeScale = 0;
            }
        }

        if(isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                riddleNote.SetActive(false);
                isOpen = false;
                Time.timeScale = 1;
            }
        }

        
    }

    public void HideNote()
    {
        riddleNote.SetActive(false);
        isOpen = false;
        Time.timeScale = 1;
    }


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

    public void LoadDay2()
    {
        SceneManager.LoadScene("Day 1");
    }

    public void LoadDay3()
    {
        SceneManager.LoadScene("Day 2");
    }

    public void LoadDay4()
    {
        SceneManager.LoadScene("Day 4");
    }

    public void LoadDay5()
    {
        SceneManager.LoadScene("Day 5");
    }
}
