using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dataManager_script : MonoBehaviour
{
    public static string username;
    public static int score;
    public static string phpAddress;

    public static bool LoggedIn { get { return username != null; } }
    public Text fie_username;
    public bool isMAMP;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("manager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        if (isMAMP)
        {
            phpAddress = "http://localhost/sqlconnect/";
        }
        else
        {
            phpAddress = "https://clients.ayzhosting.com/jjohar/";
        }
        //http://10.10.12.205/sqlconnect/ ip address of laptop at ayz

    }

    public void loadScene(int scnInd)
    {
        SceneManager.LoadScene(scnInd);
    }

    public void updateName()
    {
        username = fie_username.text;
    }

    public static void Logout()
    {
        username = null;
        SceneManager.LoadScene(0);
    }

}
