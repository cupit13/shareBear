using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class userLogin : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;
    public Text prompt;

    public void CallLogin()
    {
        StartCoroutine(LoginNum());
    }

    IEnumerator LoginNum()
    {
        WWWForm form = new WWWForm();

        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW(dataManager_script.phpAddress + "userLogin.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            dataManager_script.username = nameField.text;
            dataManager_script.score = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
            if (www.text[0] == '6')
            {
                prompt.text = "Incorrect Password";
            }
        }
    }

    public void VerifyInput()
    {
        submitButton.interactable = ((nameField.text.Length >= 4 || nameField.text.Length <= 16) && passwordField.text.Length >= 6);
    }

    public void logout()
    {
        dataManager_script.Logout();
    }

}
