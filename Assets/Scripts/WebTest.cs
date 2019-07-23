using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW request = new WWW("sqlconnect/webTest.php");
        yield return request;
        string[] webResults = request.text.Split('\t');
        foreach(string a in webResults)
        {
            Debug.Log(a);

        }
    }


}
