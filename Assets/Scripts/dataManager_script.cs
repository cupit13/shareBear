using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dataManager_script : MonoBehaviour
{
    public string username;
    public Text fie_username;
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("manager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void loadScene(int scnInd)
    {
        SceneManager.LoadScene(scnInd);
    }

    public void updateName()
    {
        username = fie_username.text;
    }
}
