using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{

    public Text textObject;

    private void Start()
    {
        textObject.text = "";
    }

    public void Write()
    {
        textObject.text = "Hello World";
    }
}
