using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{

    [Header("TextMeshPro tekster")]
    public TMP_Text lineOneText;
    public TMP_Text lineTwoText;

    [Header("Quest Mark cues")]
    public GameObject FirstMarkX;
    public GameObject SecondMarkX;
    public GameObject FirstMarkY;
    public GameObject SecondMarkY;

    [Header("Return after quest object")]
    public GameObject returnToQuest;

    [Header("Scripts")]
    public DialogueTrigger dialogueTrigger;

    [Header("Item quest")]
    public float goalAmount1;
    public float currentAmount1;

    [Header("Quest bools")]
    public bool questTwoBegun;
    public bool questThreeBegun;
    public bool canGoHome;
    public bool packageGiven;

    
    


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
        dialogueTrigger.CheckMark1_1mark();
    }

    public void Checkmark1_2()
    {
        SecondMarkY.SetActive(true);
        SecondMarkX.SetActive(false);
        dialogueTrigger.CheckMark1_2mark();
    }

    

    public void EndQuest1()
    {
        lineOneText.SetText("Return home for the night");
        lineTwoText.SetText(" ");
        FirstMarkY.SetActive(false);
        SecondMarkY.SetActive(false);
        FirstMarkX.SetActive(true);
        canGoHome = true;
        questTwoBegun = false;
    }

    public void BeginQuest2()
    {
        lineOneText.SetText("Deliver potion to either Björn or Ranus");
        lineTwoText.SetText("Gather 3 brightbloom flowers ("+currentAmount1+"/"+goalAmount1+")");
        FirstMarkX.SetActive(true);
        SecondMarkX.SetActive(true);
        questTwoBegun = true;

        
    }

    public void EndQuest2Hero()
    {
        FirstMarkY.SetActive(true);
        FirstMarkX.SetActive(false);
        dialogueTrigger.CheckMark1_1mark();
        //Give point towards hero
    }

    public void EndQuest2Villain()
    {
        FirstMarkY.SetActive(true);
        FirstMarkX.SetActive(false);
        dialogueTrigger.CheckMark1_1mark();
        // Give one point towards villain
    }

    public void EndQuest2()
    {
        lineOneText.SetText("Return home");
        lineTwoText.SetText(" ");
        Destroy(SecondMarkX);
        Destroy(SecondMarkY);
    }

    public void BeginQuest3()
    {
        lineOneText.SetText("Bring George a package");
        lineTwoText.SetText("Gather 3 brightbloom flowers and bring them to Andrew (" + currentAmount1 + "/" + goalAmount1 + ")");
        FirstMarkX.SetActive(true);
        SecondMarkX.SetActive(true);
        questThreeBegun = true;
    }




    public void PackageGiven()
    {
        packageGiven = true;
    }

    void Update()
    {
        
        if(questTwoBegun)
        {
            lineTwoText.SetText("Gather 3 brightbloom flowers (" + currentAmount1 + "/" + goalAmount1+")");
            if (currentAmount1 == goalAmount1)
            {
                SecondMarkY.SetActive(true);
                SecondMarkX.SetActive(false);
                dialogueTrigger.CheckMark1_2mark();
            }
            
        }

        if(questThreeBegun)
        {
            lineTwoText.SetText("Gather 3 brightbloom flowers and bring them to Andrew (" + currentAmount1 + "/" + goalAmount1 + ")");
            if (currentAmount1 == goalAmount1&&packageGiven)
            {
                SecondMarkY.SetActive(true);
                SecondMarkX.SetActive(false);
                dialogueTrigger.CheckMark1_2mark();
            }
        }

    }

}