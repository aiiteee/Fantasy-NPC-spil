using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSystem : MonoBehaviour
{
    //point der holder styr på ens tidligere valg.
    //statiske variabler er for at beholde information mellem scener.
    public static float björnPoints = 0;
    public static float ranusPoints = 0;

    //et point til Björn
    public void BjörnPoint()
    {
        björnPoints += 1;
    }

    //et point til Ranus
    public void RanusPoint()
    {
        ranusPoints += 1;
    }
}




