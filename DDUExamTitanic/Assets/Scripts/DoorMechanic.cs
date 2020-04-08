using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{

    public Transform doorNext;
    private GameObject player;
    private GameObject blackScreen;

    private bool activable = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        blackScreen = GameObject.FindWithTag("BlackScreen"); 
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            activable = true;
        }
        else
        {
            activable = false;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            activable = false;
        }
    }

    private void Update()
    {
        if (activable && Input.GetKeyDown("e"))
        {
            //player.transform.position = new Vector2(doorNext.position.x, doorNext.position.y+0.6f);
            StopAllCoroutines();
            StartCoroutine(BlackScreen());
        }
    }

    IEnumerator BlackScreen()
    {
        blackScreen.GetComponent<Animator>().SetBool("bScreenStart", true);
        yield return new WaitForSecondsRealtime(0.3f);
        player.transform.position = new Vector2(doorNext.position.x, doorNext.position.y + 0.6f);
        blackScreen.GetComponent<Animator>().SetBool("bScreenStart", false);

    }

}
