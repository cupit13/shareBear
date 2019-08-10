using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waresCaller : MonoBehaviour
{
    Ware curentWare;

    public void Start()
    {
        curentWare = GameObject.Find("dataManager").GetComponent<waresManager>().tempWare;
        print("my wares is " + curentWare.title);

    }

    public void callAddWare()
    {
        StartCoroutine(AddWare());
    }

    IEnumerator AddWare()
    {
        WWWForm form = new WWWForm();

        form.AddField("username", dataManager_script.username);
        form.AddField("title", curentWare.title);
        form.AddField("isAvailable", 1);
        form.AddField("availableDate", curentWare.availableDate);

        string tempDate = System.DateTime.Now.ToString();
        string date = int.Parse(tempDate.Split('/')[0]).ToString("00") + int.Parse(tempDate.Split('/')[1]).ToString("00") + tempDate.Split('/')[2].ToString().Substring(2, 3);

        form.AddField("postingDate", date);
        form.AddField("description", curentWare.description);
      
        WWW www = new WWW(dataManager_script.phpAddress + "addWare.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("ware posted succesfully");
        }
        else
        {
            Debug.Log("user created failed. Error #" + www.text);
        }
    }
}
