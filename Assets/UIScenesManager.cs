using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScenesManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Day 0");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
