using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_script : MonoBehaviour
{
    public Text playerDisplay;
    public Text scoreDisplay;

    private void Awake()
    {
        if (dataManager_script.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            playerDisplay.text = string.Format("Player : {0}", dataManager_script.username);
            scoreDisplay.text = string.Format("Score : {0}", dataManager_script.score);
        }


    }

    public void callSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", dataManager_script.username);
        form.AddField("score", dataManager_script.score);

        WWW www = new WWW("https://clients.ayzhosting.com/jjohar/savedata.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Save failed. error #" + www.text);

        }

        dataManager_script.Logout();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void increaseScore()
    {
        dataManager_script.score++;
        scoreDisplay.text = string.Format("Score : {0}", dataManager_script.score);

    }
}
