using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    public bool isInZone=false;

    public GameObject DialogueBox;
    public GameObject Interactor;

    public PlayerMovement script;


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

    private void Update()
    {
        if (isInZone)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                DialogueBox.SetActive(true);
                Interactor.SetActive(false);
                script.moveSpeed = 0f;
            }
        }


    }
}
