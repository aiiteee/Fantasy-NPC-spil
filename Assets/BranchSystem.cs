using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSystem : MonoBehaviour
{
    //make static later when tests are finished
    public float bj�rnPoints = 0;
    public float ranusPoints = 0;

    public void Bj�rnPoint()
    {
        bj�rnPoints += 1;
    }

    public void RanusPoint()
    {
        ranusPoints += 1;
    }
}
