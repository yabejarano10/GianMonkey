using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCollection 
{
    public Json[] data;
    public string collectionName;

    public override string ToString()
    {
        string result = "Data\n";
        foreach(var item in data)
        {
            result += string.Format("Data: ",item);
            collectionName = item.Title;
            Debug.Log(collectionName);
        }
        return result;
    }
}
