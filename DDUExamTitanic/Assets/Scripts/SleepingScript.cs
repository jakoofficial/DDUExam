using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepingScript : MonoBehaviour
{
    public Animator blackScreen;
    private GameObject interactableKey;
    public string sceneName;

    private bool collision = false;

    private void Start()
    {
        interactableKey = GameObject.FindWithTag("interactableKey");
    }

    private void Update()
    {
        if (collision && Input.GetKeyDown(KeyCode.E))
        {
            Sleep();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            collision = true;
            interactableKey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            collision = false;
            interactableKey.SetActive(false);
        }
    }

    public void Sleep()
    {
        blackScreen.SetBool("bScreenStart", true);
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
