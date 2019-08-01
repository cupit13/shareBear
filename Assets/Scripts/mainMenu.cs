using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public string username;
    public Text prompt;
    public Text loginText;
    public Button playGame;
    public Button registerButton;

    private void Start()
    {
        resetUser();
        registerButton.interactable = !dataManager_script.LoggedIn;

}

public void GoToRegister()
        {
        SceneManager.LoadScene(1);
        }

    void resetUser()
    {
        username = dataManager_script.username;

        if (username == null)
        {
            prompt.text = "No user logged in...";
            loginText.text = "Log In";
        }
        else
        {
            prompt.text = "Welcome " + username;
            loginText.text = "Sign Out";
            VerifyUser();
        }
    }

    public void GoToLogin()
    {
        if(username == null)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            dataManager_script.username = null;
            resetUser();
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }

    public void VerifyUser()
    {
        playGame.interactable = true;
    }
}
