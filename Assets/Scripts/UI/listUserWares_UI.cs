using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class listUserWares_UI : MonoBehaviour
{
    public GameObject itemDupe;
    public GameObject par;

    private void Start()
    {


    }

    void resetContentChildren()
    {
        foreach (Transform child in par.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    public void renderUserWare(List<string> items, List<string> users = null)
    {
        resetContentChildren();

        for (int i = 0; i < items.Count; i++)
        {
            GameObject dupe = Instantiate(itemDupe, par.transform);
            dupe.GetComponent<RectTransform>().localPosition = new Vector3(480, (-61 + (-125 * i)), 0);
            int mod = i % 2;
            if (mod > 0)
            {
                dupe.GetComponent<Image>().color = new Color(.85f, .85f, .85f);
            }
            dupe.name = items[i];
            dupe.transform.GetComponentInChildren<Text>().text = items[i];
            par.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 1275 + (Mathf.Clamp(i - 10, 0, 1000) * 150));
            
            if (users != null)
            {
                dupe.GetComponent<classItems_UI>().owner.text = users[i];
            }
        }

    }
}
