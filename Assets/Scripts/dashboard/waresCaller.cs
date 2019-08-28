using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class waresCaller : MonoBehaviour
{
    Ware curentWare;
    public GameObject addWarePanel;
    public GameObject clickBlocker;
    public InputField titleInput;
    public InputField availableDateInput;
    public InputField descInput;
    public GameObject successPromptObj;
    public Button submitBtn;

    public void Start()
    {
        refreshCurWare();
    }

    void refreshCurWare()
    {
            curentWare = GameObject.Find("dataManager").GetComponent<waresManager>().tempWare;
    }

    public void addNewWareUIOn()
    {
        titleInput.text = null;
        availableDateInput.text = null;
        descInput.text = null;
        submitBtn.interactable = false;
        clickBlocker.SetActive(true);
        addWarePanel.SetActive(true);
    }

    public void addNewWareUIOff()
    {
        clickBlocker.SetActive(false);
        addWarePanel.SetActive(false);
    }

    void copyUIToDataMan()
    {
        curentWare.title = titleInput.text;
        curentWare.availableDate = availableDateInput.text;
        curentWare.description = descInput.text;
    }

    public void submitWare()
    {
        copyUIToDataMan();
        addNewWareUIOff();
        StartCoroutine(AddWare());
    }

    public void validateInput()
    {
        if(titleInput.text.Length <= 32 && validateDate(availableDateInput.text) && titleInput.text.Length >= 4)
        {
            submitBtn.interactable = true;
        }
        else
        {
            submitBtn.interactable = false;
        }
    }

    bool validateDate(string inputDate)
    {
        if ( inputDate.Length == 6)
        {
            string a = inputDate;
            int numericInputDate = int.Parse(string.Format("{0}{1}{2}{3}{4}{5}", a[4], a[5], a[0], a[1], a[2], a[3]));
            string b = todaysDate();
            int numericTodaysDate = int.Parse(string.Format("{0}{1}{2}{3}{4}{5}", b[4], b[5], b[0], b[1], b[2], b[3]));
            //check that the date is not in the past
            if (numericInputDate >= numericTodaysDate)
            {
                return true;
            }
            else
            {
                //date is before today
                return false;
            }
        }
        else
        {
            //Debug.Log("date input is not 6 characters");
            return false;
        }
    }

    string todaysDate()
    {
        string tempDate = System.DateTime.Now.ToString();
        string date = int.Parse(tempDate.Split('/')[0]).ToString("00") + int.Parse(tempDate.Split('/')[1]).ToString("00") + tempDate.Split('/')[2].ToString().Substring(2, 2);
        return date;
    }

    public void insertTodaysDate()
    {
        availableDateInput.text = todaysDate();
    }

    IEnumerator AddWare()
    {
        WWWForm form = new WWWForm();

        form.AddField("username", dataManager_script.username);
        form.AddField("title", curentWare.title);
        form.AddField("isAvailable", 1);
        form.AddField("availableDate", curentWare.availableDate);

        form.AddField("postingDate", todaysDate());
        form.AddField("description", curentWare.description);
      
        WWW www = new WWW(dataManager_script.phpAddress + "addWare.php", form);
        yield return www;

        if (www.text == "0")
        {
            StartCoroutine(successPrompt());
            Debug.Log("ware posted succesfully");
        }
        else
        {
            Debug.Log("user created failed. Error #" + www.text);
        }
    }

    IEnumerator successPrompt()
    {
        successPromptObj.SetActive(true);
        yield return new WaitForSeconds(2);
        successPromptObj.SetActive(false);
    }

    public void loadScene(int scnInd)
    {
        SceneManager.LoadScene(scnInd);
    }
}
