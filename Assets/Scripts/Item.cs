using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip clip;
    public float volume = 1;
    public bool canPickUp;
    public QuestManager questManager;

    // Update is called once per frame
    void Update()
    {
        if(canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.F)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position, volume);
                Destroy(gameObject);
                questManager.currentAmount += 1;
            }

        }
    }
    

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }
}