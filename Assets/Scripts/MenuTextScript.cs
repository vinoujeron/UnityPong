using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuTextScript : MonoBehaviour
{
    public Text thisText;
    private void OnMouseOver()
    {
        thisText = GetComponent<Text>();
        thisText.fontSize = 80;
        Debug.Log(1);
    }
    
    private void OnMouseExit()
    {
        thisText = GetComponent<Text>();
        thisText.fontSize = 75;
        Debug.Log(2);
    }
}
