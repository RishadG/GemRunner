using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SettingsMenu;
    public GameObject WelcomeScreen;
    public GameObject CreditsScreen;


    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void showSettings()
    {
        WelcomeScreen.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void showWelcomeScreen()
    {
        SettingsMenu.SetActive(false);
        CreditsScreen.SetActive(false);
        WelcomeScreen.SetActive(true);
    }
    public void showCredits()
    {
        WelcomeScreen.SetActive(false);
        CreditsScreen.SetActive(true);
    }
}
