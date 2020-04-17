using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepingScript : MonoBehaviour
{
    public Animator blackScreen;
    public string sceneName;

    private bool collision = false;

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
