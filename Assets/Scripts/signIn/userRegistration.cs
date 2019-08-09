using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userRegistration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public Text promptDisplay;


    public void callRegister()
    {
        if ((nameField.text.Length >= 4 || nameField.text.Length <= 16) && passwordField.text.Length >= 6)
        {
            StartCoroutine(Register());
        }
        else
        {
            promptDisplay.text = "username must be between 4 and 16 characters long, password 6 characters long";
        }
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();

        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW(dataManager_script.phpAddress + "userRegister.php", form);
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

    public void logout()
    {
        dataManager_script.Logout();
    }

}
