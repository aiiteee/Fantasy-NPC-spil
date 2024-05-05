using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [Header("Map object")]
    public GameObject mapUI;

    [Header("Map images")]
    public GameObject mapVersion1;
    public GameObject mapVersion2;
    public GameObject mapVersion3;
    public GameObject mapVersion4;
    public GameObject mapVersion5;

    [Header("Boolian")]
    public bool mapIsShowing=false;
    public bool isDay1=false;

    public void Update()
    {
        if (!mapIsShowing)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMap();
                Time.timeScale = 0;
            }
        }

        if (mapIsShowing)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideMap();
                Time.timeScale = 1;
            }
        }

        
    }

    public void ShowMap()
    {
        mapUI.SetActive(true);
        mapIsShowing = true;
    }

    public void HideMap()
    {
        mapUI.SetActive(false);
        mapIsShowing = false;
    }



    public void ShowMap2()
    {
        mapVersion1.SetActive(false);
        mapVersion2.SetActive(true);
    }

    public void ShowMap3()
    {
        mapVersion2.SetActive(false);
        mapVersion3.SetActive(true);
    }

    public void ShowMap4()
    {
        mapVersion3.SetActive(false);
        mapVersion4.SetActive(true);
    }

    public void ShowMap5()
    {
        mapVersion4.SetActive(false);
        mapVersion5.SetActive(true);
    }
    
}
