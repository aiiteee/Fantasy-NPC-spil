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

    [Header("Game Objects")]
    public GameObject returnToQuest;
    public GameObject trigger;
    public GameObject charlotteTrigger;
    public GameObject squireTrigger;
    public GameObject shopkeeperTeaTrigger;
    public GameObject shopkeeperSugarTrigger;
    public GameObject shopkeeperTea;
    public GameObject shopkeeperSugar;
    public GameObject marigold;
    public GameObject squire;
    public GameObject björn;
    public GameObject ranus;
    

    [Header("Scripts")]
    public DialogueTrigger dialogueTrigger;
    public Item item;
    public BranchSystem branchSystem;

    [Header("Item quest")]
    public float goalAmount1;
    public float currentAmount1;

    [Header("Quest bools")]
    public bool questTwoBegun;
    public bool questThreeBegun;
    public bool questFourBegun;
    public bool canGoHome;
    public bool packageGiven;
    public bool packageGivenAndrew=false;
    public bool pickUpSword;
    public bool swordFound;
    public bool shopkeeperDone;
    public bool squireFinished;
    public bool charlotteFinished;

    public bool situation1;
    public bool situation2;
    public bool situation3;
    public bool situation4;

    public bool heroEnding;
    public bool villainEnding;

    [Header("Positions")]
    public Transform squireSpeechPosition;



    public void Awake()
    {
        trigger.SetActive(false);

        charlotteTrigger.SetActive(false);
        squireTrigger.SetActive(false);
        shopkeeperTeaTrigger.SetActive(false);
        shopkeeperSugarTrigger.SetActive(false);
        marigold.SetActive(false);
        squire.SetActive(false);
        björn.SetActive(false);
    }

    

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
        //lineTwoText.SetText("Gather 3 brightbloom flowers ("+currentAmount1+"/"+goalAmount1+")");
        FirstMarkX.SetActive(true);
        SecondMarkX.SetActive(true);
        questTwoBegun = true;

        
    }

    public void EndQuest2Hero()
    {
        FirstMarkY.SetActive(true);
        FirstMarkX.SetActive(false);
        dialogueTrigger.CheckMark1_1mark();
        // Give one point towards Björn
        BranchSystem.björnPoints+=1;
    }

    public void EndQuest2Villain()
    {
        FirstMarkY.SetActive(true);
        FirstMarkX.SetActive(false);
        dialogueTrigger.CheckMark1_1mark();
        // Give one point towards villain
        BranchSystem.ranusPoints+=1;
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
        dialogueTrigger.questBegun = true;
        
    }

    public void BeginQuest3part2()
    {
        lineOneText.SetText("Bring the potion to Björn");
        
        FirstMarkX.SetActive(true);
        FirstMarkY.SetActive(false);
        SecondMarkY.SetActive(false);
        dialogueTrigger.finishedQuest = false;
        
    }

    public void UpdateQuest3part2()
    {
        lineOneText.SetText("Return to Björn");
        //Stop timer
        dialogueTrigger.finishedQuest = true;
    }

    public void BeginQuest4()
    {
        lineOneText.SetText("Get Chocolate from Charlotte at the market");
        lineTwoText.SetText("Gather 5 brightbloom flowers (" + currentAmount1 + "/" + goalAmount1 + ")");
        FirstMarkX.SetActive(true);
        SecondMarkX.SetActive(true);
        questFourBegun = true;
        
    }

    public void Quest4Situation1()
    {
        situation1 = true;
        shopkeeperTeaTrigger.SetActive(true);
        squire.SetActive(true);
    }

    public void Quest4Situation2()
    {
        situation2 = true;
        charlotteTrigger.SetActive(true);
        squire.SetActive(true);
        squireTrigger.SetActive(false);
        shopkeeperSugarTrigger.SetActive(true);

        björn.SetActive(true);
        squire.transform.position = squireSpeechPosition.position;
    }

    public void Quest4Situation3()
    {
        situation3 = true;
        marigold.SetActive(true);
        shopkeeperSugarTrigger.SetActive(true);
        ranus.SetActive(false);

        squire.SetActive(true);
        björn.SetActive(true);
        squire.transform.position = squireSpeechPosition.position;
    }

    public void Quest4Situation4()
    {
        situation4 = true;
        charlotteTrigger.SetActive(true);
    }

    public void EndSituation()
    {
        dialogueTrigger.CheckMark1_1mark();
        FirstMarkY.SetActive(true);
        FirstMarkX.SetActive(false);
    }

    public void EndQuest4()
    {
        lineOneText.SetText("Return home for the night");
        lineTwoText.SetText(" ");
        FirstMarkY.SetActive(false);
        SecondMarkY.SetActive(false);
        FirstMarkX.SetActive(true);
        canGoHome = true;
    }

    public void EndGameHero()
    {
        lineOneText.SetText("Return home for the night");
        lineTwoText.SetText(" ");
        FirstMarkY.SetActive(false);
        SecondMarkY.SetActive(false);
        FirstMarkX.SetActive(true);
        canGoHome = true;
        heroEnding = true;
    }

    public void EndGameVillain()
    {
        lineOneText.SetText("Return home for the night");
        lineTwoText.SetText(" ");
        FirstMarkY.SetActive(false);
        SecondMarkY.SetActive(false);
        FirstMarkX.SetActive(true);
        canGoHome = true;
        villainEnding = true;
    }



    public void PackageGiven()
    {
        packageGiven = true;
    }

    public void PackageGivenAndrew()
    {
        packageGivenAndrew=true;
    }

    void Update()
    {
        
        if(questTwoBegun)
        {
            lineTwoText.SetText("Gather 3 brightbloom flowers (" + currentAmount1 + "/" + goalAmount1 + ")");
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
            if (currentAmount1 == goalAmount1&&packageGivenAndrew)
            {
                SecondMarkY.SetActive(true);
                SecondMarkX.SetActive(false);
                dialogueTrigger.CheckMark1_2mark();
                
            }

            if (dialogueTrigger.finishedQuest)
            {
                questThreeBegun= false;
                lineTwoText.SetText("");
            }

            if(currentAmount1 == goalAmount1)
            {
                trigger.SetActive(true);
            }
                
        }

        if(questFourBegun)
        {
            lineTwoText.SetText("Gather 5 brightbloom flowers (" + currentAmount1 + "/" + goalAmount1 + ")");
            if (currentAmount1 == goalAmount1)
            {
                SecondMarkY.SetActive(true);
                SecondMarkX.SetActive(false);
                dialogueTrigger.CheckMark1_2mark();
            }

            if(dialogueTrigger.finishedQuest)
            {
                questFourBegun = false;
                lineOneText.SetText("Return to Kensleigh");
                lineTwoText.SetText(" ");
                FirstMarkY.SetActive(false);
                SecondMarkY.SetActive(false);
                FirstMarkX.SetActive(true);
            }
        }

        if (situation1)
        {
            if (shopkeeperDone)
            {
                charlotteTrigger.SetActive(true);
                if(charlotteFinished)
                {
                    charlotteTrigger.SetActive(false);
                    EndSituation();
                }
            }
        }

        if(situation2 && shopkeeperDone)
        {
            squireTrigger.SetActive(true);
            if(squireFinished)
            {
                squireTrigger.SetActive(false);
                EndSituation();
            }
        }

        if (situation3 && shopkeeperDone)
        {
            charlotteTrigger.SetActive(true);
            if(charlotteFinished)
            {
                charlotteTrigger.SetActive(false);
                squireTrigger.SetActive(true);
                if (squireFinished)
                {
                    squireTrigger.SetActive(false);
                    EndSituation();
                }
            }
        }

        if (situation4 && charlotteFinished)
        {
            charlotteTrigger.SetActive(false);
            EndSituation();
        }

        

        if (dialogueTrigger.newText)
        {
            if (!swordFound)
            {
                lineOneText.SetText("Find Björns sword (press Q for description)");
                lineTwoText.SetText(" ");
                //start timer
                pickUpSword = true;
            }

            if(swordFound)
            {
                lineOneText.SetText("Return to Björn");
                dialogueTrigger.finishedQuest = true;
                villainEnding=true;
            }

            if (canGoHome)
            {
                EndQuest1();
            }
            /*else
            {
                lineOneText.SetText("Bring the potion to Björn");

                FirstMarkX.SetActive(true);
                FirstMarkY.SetActive(false);
                SecondMarkY.SetActive(false);
                dialogueTrigger.finishedQuest = false;
            }*/
            
            

            
        }
    }

}