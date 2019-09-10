using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waresLister : MonoBehaviour
{
    GameObject dataMan;

    private void Start()
    {
        dataMan = GameObject.Find("dataManager");
    }

    public void populateUserWares()
    {
        StartCoroutine(CallAskUserWares());

    }

    public void populateOtherWares()
    {
        StartCoroutine(CallAskOtherWares());

    }

    void addOneWare(List<Ware> wareList, int itemID, string title, int owner, bool isAvailable, string availableDate, string postDate, string description, string username)
    {
        Ware newWare = new Ware();

        newWare.itemID = itemID;
        newWare.title = title;
        newWare.owner = owner;
        newWare.isAvailable = isAvailable;
        newWare.availableDate = availableDate;
        newWare.postDate = postDate;
        newWare.description = description;
        newWare.username = username;

        wareList.Add(newWare);
    }

    void resetUserWares()
    {

        dataMan.GetComponent<waresManager>().userWares.Clear();
    }

    void resetOtherWares()
    {

        dataMan.GetComponent<waresManager>().browseWares.Clear();
    }

    IEnumerator CallAskUserWares()
    {
        WWWForm form = new WWWForm();

        string username = dataManager_script.username;
        
        if (username == "")
        {
            username = "jeffjohar";
        }

        form.AddField("username", dataManager_script.username);

        WWW www = new WWW(dataManager_script.phpAddress + "listUserWares.php", form);
        yield return www;

        string[] rows = www.text.Split('\n');

        resetUserWares();

        for (int i=0;i<rows.Length-1; i++)
        {
            string[] columns = rows[i].Split('\t');
            addOneWare(dataMan.GetComponent<waresManager>().userWares, int.Parse(columns[0]), columns[1], int.Parse(columns[2]), int.Parse(columns[3]) >0 ?true:false, columns[4], columns[5], columns[6], columns[7]);          
        }

        //UI
        List<string> items = new List<string>();
        foreach (Ware item in dataMan.GetComponent<waresManager>().userWares)
        {
            items.Add(item.title);
        }
        GetComponent<listUserWares_UI>().renderUserWare(items);
    }

    IEnumerator CallAskOtherWares()
    {
        WWWForm form = new WWWForm();

        string username = dataManager_script.username;

        if (username == "")
        {
            username = "jeffjohar";
        }

        form.AddField("username", dataManager_script.username);

        WWW www = new WWW(dataManager_script.phpAddress + "listOtherWares.php", form);
        yield return www;

        string[] rows = www.text.Split('\n');

        resetOtherWares();

        for (int i = 0; i < rows.Length - 1; i++)
        {
            string[] columns = rows[i].Split('\t');
            addOneWare(dataMan.GetComponent<waresManager>().browseWares, int.Parse(columns[0]), columns[1], int.Parse(columns[2]), int.Parse(columns[3]) > 0 ? true : false, columns[4], columns[5], columns[6], columns[7]);
        }

        //UI
        List<string> items = new List<string>();
        foreach (Ware item in dataMan.GetComponent<waresManager>().browseWares)
        {
            items.Add(item.title);
        }

        List<string> users = new List<string>();
        foreach (Ware item in dataMan.GetComponent<waresManager>().browseWares)
        {
            users.Add(item.username);
        }

        GetComponent<listUserWares_UI>().renderUserWare(items,users =users);
    }
}
