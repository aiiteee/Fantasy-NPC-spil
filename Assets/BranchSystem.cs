using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSystem : MonoBehaviour
{
    //point der holder styr p� ens tidligere valg.
    //statiske variabler er for at beholde information mellem scener.
    public static float bj�rnPoints = 0;
    public static float ranusPoints = 0;

    //et point til Bj�rn
    public void Bj�rnPoint()
    {
        bj�rnPoints += 1;
    }

    //et point til Ranus
    public void RanusPoint()
    {
        ranusPoints += 1;
    }
}




