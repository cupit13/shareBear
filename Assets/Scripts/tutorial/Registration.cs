﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public Text promptDisplay;


    public void callRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();

        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("https://clients.ayzhosting.com/jjohar/register.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("user created succesfully");
            //dataManager_script.username = nameField.text;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("user created failed. Error #" + www.text);
            if (www.text[0] == '3')
            {
                promptDisplay.text = "Username already taken!";
            }
        }
    }

    public void VerifyInput()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

    public void logout()
    {
        dataManager_script.Logout();
    }

}
