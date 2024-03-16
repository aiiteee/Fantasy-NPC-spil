using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Interactor;

    public void ActivateInteractor()
    {
        Interactor.SetActive(true);
    }

    public void DeActivateInteractor()
    {
        Interactor.SetActive(false);
    }

}
