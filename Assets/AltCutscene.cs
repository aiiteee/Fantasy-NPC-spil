using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCutscene : MonoBehaviour
{
    public GameObject CloseCutSceneButton;
    public GameObject CutScene;

    public PlayerMovement playerMovement;

    void Awake()
    {
        StartCoroutine(WaitButton());
        playerMovement.moveSpeed=0f;
    }

    IEnumerator WaitButton() 
    {
        yield return new WaitForSeconds(10f);
        CloseCutSceneButton.SetActive(true);
    }

    public void CloseCutScene()
    {
        CutScene.SetActive(false);
        playerMovement.moveSpeed=5f;
    }
    

}
