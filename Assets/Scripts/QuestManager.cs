using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public bool isActive;

    //public string questText1;
    //public string questText2;
    public int goalAmount;
    public int currentAmount;

    public TMP_Text lineOneText;
    public TMP_Text lineTwoText;

    public GameObject FirstMarkX;
    public GameObject SecondMarkX;
    public GameObject FirstMarkY;
    public GameObject SecondMarkY;

    


    public void BeginQuest1()
    {
        lineOneText.SetText("Bring the package to Marigold the baker");
        lineTwoText.SetText("Bring the package to George the smith");
        FirstMarkX.SetActive(true);
        SecondMarkX.SetActive(true);
    }

    public void Checkmark1_1()
    {
        FirstMarkY.SetActive(true);
        FirstMarkX.SetActive(false);
        
    }

    public void Checkmark1_2()
    {
        SecondMarkY.SetActive(true);
        SecondMarkX.SetActive(false);
        
    }

}