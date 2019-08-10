using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ware :System.Object
{
    public int itemID;
    public string title;
    public int owner;
    public bool isAvailable;
    public string availableDate;
    public string postDate;
    public string description;
}
