using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPopUp : MonoBehaviour
{
    [Header("Gameobjects")]
    public GameObject letters;
    public GameObject villainOpenLetter;
    public GameObject heroOpenLetter;
    public GameObject closeLetters;

    private bool villainOpen;
    private bool heroOpen;
    private bool hasOpenedHero;
    private bool hasOpenedVillain;

    
    public void ActivateLetters()
    {
        letters.SetActive(true);
    }

    public void DeactivateLetters()
    {
        letters.SetActive(false);
    }


    public void ReadVillain()
    {
        villainOpenLetter.SetActive(true);
        villainOpen = true;
        
    }

    public void ReadHero()
    {
        heroOpenLetter.SetActive(true);
        heroOpen = true;
        
    }

    public void CloseLetter()
    {
        if(villainOpen)
        {
            villainOpenLetter.SetActive(false);
            villainOpen= false;
            hasOpenedHero = true;
        }

        if (heroOpen)
        {
            heroOpenLetter.SetActive(false);
            heroOpen = false;
            hasOpenedVillain = true;
        }
    }

    public void Update()
    {
        if(hasOpenedHero && hasOpenedVillain) 
        {
            closeLetters.SetActive(true);
        }
    }
    
}
