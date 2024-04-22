using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menuBars;
    public GameObject questsWindow;
    public GameObject map;
    public GameObject inventory;
    public GameObject activeQuests;
    public GameObject icons;
    

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
}
