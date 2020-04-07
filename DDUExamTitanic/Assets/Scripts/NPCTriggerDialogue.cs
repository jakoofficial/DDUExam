using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTriggerDialogue : MonoBehaviour
{
    public DialogueTrigger dialogue;
    private bool talkative = false;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("starts convo");
            talkative = true;
        }
        else
        {
            talkative = false;
        }
    }

    private void Update()
    {
        if (talkative && Input.GetKeyDown("e"))
        {
            Debug.Log("starts convosation");
            dialogue.TriggerDialogue();
        }
    }
}
