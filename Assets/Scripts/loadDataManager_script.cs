using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadDataManager_script : MonoBehaviour
{
    dataManager_script dataScript;

    // Start is called before the first frame update
    void Start()
    {
        dataScript = GameObject.Find("dataManager").GetComponent<dataManager_script>();
        welcomeNameUpdate();
    }

    void welcomeNameUpdate()
    {
        GetComponent<Text>().text = "Welcome \n" + dataScript.username;
    }
}
