using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject startANewGameText;
    public GameObject playerText;
    public GameObject computerText;
    public GameObject QuitText;
    
    public GameObject EasyText;
    public GameObject NormalText;
    public GameObject UnrealText;
    
    public GameObject SelectDifficultyText;

    private void Awake()
    {
        playerText.SetActive(false);
        computerText.SetActive(false);
        EasyText.SetActive(false);
        NormalText.SetActive(false);
        UnrealText.SetActive(false);
        SelectDifficultyText.SetActive(false);
    }

    public void StartButtonEvent()
    {
        startANewGameText.SetActive(false);
        playerText.SetActive(true);
        computerText.SetActive(true);
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartWithAI()
    {
        playerText.SetActive(false);
        computerText.SetActive(false);
        
        EasyText.SetActive(true);
        NormalText.SetActive(true);
        UnrealText.SetActive(true);
        SelectDifficultyText.SetActive(true);
        
        QuitText.transform.position += new Vector3(0, -75, 0);
        GameManager.IsSecondPlayerAI = true;
    }

    public void StartWithoutAI()
    {
        GameManager.IsSecondPlayerAI = false;
        SceneManager.LoadScene(1);    
    }

    public void StartWithEasyAI()
    {
        GameManager.difficultyVariable = 15f;
        SceneManager.LoadScene(1);
    }
    
    public void StartWithNormalAI()
    {
        GameManager.difficultyVariable = 10f;
        SceneManager.LoadScene(1);
    }
    
    public void StartWithUnrealAI()
    {
        GameManager.difficultyVariable = 7.5f;
        SceneManager.LoadScene(1);
    }
}
