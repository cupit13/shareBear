using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    public void executeWebTest()
    {
        StartCoroutine(webTestThis());
    }

    IEnumerator webTestThis()
    {
        WWWForm form = new WWWForm();

        form.AddField("name", dataManager_script.username);

        WWW www = new WWW("https://clients.ayzhosting.com/jjohar/webTest.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            Debug.Log("sucess" + www.text);
        }
        else
        {
            Debug.Log("fail" + www.text);
        }
    }

    public void saveToUserPrefs()
    {
        //PlayerPrefs.SetString("username", "bobo");
        string name = PlayerPrefs.GetString("username");
        print($"username is: {name}");

    }

    public void printAuto()
    {
        print(dataManager_script.isAutoLogin);
    }
}
