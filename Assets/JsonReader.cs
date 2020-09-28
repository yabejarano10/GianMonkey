using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonReader : MonoBehaviour {
    private string jsonPath = "";

    private DataCollection dataCollection;
    [SerializeField]
    private UIManager uiManager;

    public void LoadData () 
    {
        using (StreamReader stream = new StreamReader (jsonPath)) {
            string json = stream.ReadToEnd ();
            var data = JsonUtility.FromJson<Json> (json);
            uiManager.UpdateTable(data);
        }
    }

    void Start () {
        jsonPath = $"{Application.dataPath}/StreamingAssets/JsonChallenge.json";
        LoadData ();
    }
}