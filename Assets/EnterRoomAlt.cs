using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoomAlt : MonoBehaviour
{
    [SerializeField] Transform posToGo;
    public GameObject player;
    public GameObject leaveRoomUI;

    public bool isInRange;
    



    void Update()
    {
        if (isInRange)
        {
            leaveRoomUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.transform.position = posToGo.position;
            }
        }
        else
        {
            leaveRoomUI.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }

    }
}
