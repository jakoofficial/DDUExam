using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTriggerDialogue : MonoBehaviour
{
    public DialogueTrigger dialogue;
    private GameObject interactableKey;
    private bool talkative = false;

    private void Start()
    {
        interactableKey = GameObject.FindWithTag("interactableKey");
        StartCoroutine(removeInteractKey());
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            talkative = true;
            interactableKey.SetActive(true);
        }
        else
        {
            talkative = false;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            talkative = false;
            interactableKey.SetActive(false);
        }
    }

    private void Update()
    {
        if (talkative && Input.GetKeyDown("e"))
        {
            Debug.Log("starts convosation");
            dialogue.TriggerDialogue();
            interactableKey.SetActive(false);
        }
    }

    IEnumerator removeInteractKey()
    {
        yield return new WaitForSeconds(1f);
        interactableKey.SetActive(false);
    }
}
