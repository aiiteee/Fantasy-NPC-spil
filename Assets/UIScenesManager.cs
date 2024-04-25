using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScenesManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Town Building");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
