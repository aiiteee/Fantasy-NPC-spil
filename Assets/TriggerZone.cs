using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    public bool isInZone=false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter.Invoke();

        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExit.Invoke();

        if (other.CompareTag("Player"))
        {
            isInZone = false;
        }
    }
}
