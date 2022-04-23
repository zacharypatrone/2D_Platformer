// Zachary Patrone
// CS583 - Professor Price
// 4/15/2022
// Script for Main Menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuController : MonoBehaviour
{
    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void About()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void EasyDifficulty()
    {
        SceneManager.LoadScene(3);
    }

    public void MediumDifficulty()
    {
        SceneManager.LoadScene(3);
    }

    public void HardDifficulty()
    {
        SceneManager.LoadScene(3);
    }

}
