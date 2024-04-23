using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public bool isActive;

    public string questText1;
    public string questText2;
    public int goalAmount;
    public int currentAmount;

    public TMP_Text lineOneText;
    public TMP_Text lineTwoText;

    public void BeginQuest()
    {
        lineOneText.SetText(questText1);
        lineTwoText.SetText(questText2);
    }
}