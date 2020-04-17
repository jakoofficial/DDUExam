using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStart : MonoBehaviour
{
    public Animator blackscreenNewDay;
    public Text newDayText;
    public string newDayString;

    private void Start()
    {
        newDayText.text = newDayString.ToString();
        blackscreenNewDay.SetBool("newDay", true);
        StartCoroutine(newDay());
    }

    IEnumerator newDay()
    {
        yield return new WaitForSeconds(1.5f);
        blackscreenNewDay.SetBool("newDay", false);
    }
}
