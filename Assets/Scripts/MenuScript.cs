using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button button;

    public void StartGame()
    {
        SceneManager.LoadScene(1);    
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void OnPointEnterEvent(Text text)
    {
        text.fontSize = 80;
        Debug.Log("EnterEvent");
    }

    public void OnPointExitEvent(Text text)
    {
        text.fontSize = 75;
        Debug.Log("ExitEvent");
    }
}
