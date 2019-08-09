using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadDataManager_script : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        welcomeNameUpdate();
    }

    void welcomeNameUpdate()
    {
        GetComponent<Text>().text = "Welcome \n" + dataManager_script.username;
    }
}
