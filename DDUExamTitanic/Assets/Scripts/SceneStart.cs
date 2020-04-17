﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStart : MonoBehaviour
{
    public Animator blackscreenNewDay;
    public Text newDayText;
    public Text newDayTitle;
    public string newDayString;
    public string newDayTitleString;

    private void Start()
    {
        newDayText.text = newDayString.ToString();
        newDayTitle.text = newDayTitleString.ToString();
        blackscreenNewDay.SetBool("newDay", true);
        StartCoroutine(newDay());
    }

    IEnumerator newDay()
    {
        yield return new WaitForSeconds(2f);
        blackscreenNewDay.SetBool("newDay", false);
    }
}
