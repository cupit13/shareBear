using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class autoSignInPrefs : MonoBehaviour
{
    public InputField usernameField;
    public InputField pwField;
    public Toggle checkmark;

    private void Start()
    {
        string username = PlayerPrefs.GetString("username");
        if (username != "")
        {
            autoLogIn();
        }
        else
        {
            print("no user prefs saved");
        }
    }

    public void saveUserPW()
    {
        if (checkmark.isOn)
        {
            PlayerPrefs.SetString("username", usernameField.text);
            PlayerPrefs.SetString("password", pwField.text);
            print("saving prefs");
        }

    }

    void autoLogIn()
    {
        if (dataManager_script.isAutoLogin)
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            if (y == 0 && dataManager_script.username == null)
            {
                gameObject.GetComponent<userMainMenu>().GoToLogin();
            }
            else if (y == 2)
            {
                string username = PlayerPrefs.GetString("username");
                string pw = PlayerPrefs.GetString("password");
                gameObject.GetComponent<userLogin>().nameField.text = username;
                gameObject.GetComponent<userLogin>().passwordField.text = pw;
                gameObject.GetComponent<userLogin>().CallLogin();
            }
        }
    }
}
