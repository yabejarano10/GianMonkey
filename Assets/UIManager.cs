using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private Text Title;
    // Start is called before the first frame update
    void ClearTable () {
        foreach (Transform child in Canvas.transform) {
            if (child.gameObject.tag == "data") {
                GameObject.Destroy (child.gameObject);
            }
        }
    }

    public void UpdateTable (Json data) {
        ClearTable ();
        Title.text = data.Title;
        float headerAdvance = 625 / data.ColumnHeaders.Length;
        float headerlastPos = -275f;
        for (var i = 0; i < data.ColumnHeaders.Length; i++) {
            GameObject newGO = new GameObject ("myHeader" + i);
            newGO.tag = "data";
            newGO.transform.SetParent (Canvas.transform);
            Text header = newGO.AddComponent<Text> ();
            Font ArialFont = (Font) Resources.GetBuiltinResource (typeof (Font), "Arial.ttf");

            header.text = data.ColumnHeaders[i];
            header.font = ArialFont;
            header.fontStyle = FontStyle.Bold;
            header.alignment = TextAnchor.MiddleCenter;
            header.fontSize = 20;

            header.GetComponent<RectTransform> ().localPosition = new Vector3 (headerlastPos, 125f, 0f);
            header.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);

            headerlastPos += headerAdvance;
        }

        float dataAdvance = 253 / data.Data.Length;
        float dataLastPos = 90f;

        for (var j = 0; j < data.Data.Length; j++) {
            float horizontalAdvance = 625 / data.ColumnHeaders.Length;
            float lastPosH = -275f;

            AddElement (j, data.Data[j].ID, lastPosH, dataLastPos);
            lastPosH += horizontalAdvance;

            AddElement (j, data.Data[j].Name, lastPosH, dataLastPos);
            lastPosH += horizontalAdvance;

            AddElement (j, data.Data[j].Role, lastPosH, dataLastPos);
            lastPosH += horizontalAdvance;

            AddElement (j, data.Data[j].Nickname, lastPosH, dataLastPos);
            dataLastPos -= dataAdvance;

        }

    }
    void AddElement (float index, string data, float horizontalPos, float verticalPos) 
    {
        GameObject newGO = new GameObject ("myData" + index);

        newGO.tag = "data";
        newGO.transform.SetParent (Canvas.transform);
        Text idData = newGO.AddComponent<Text> ();
        Font ArialFont = (Font) Resources.GetBuiltinResource (typeof (Font), "Arial.ttf");

        idData.text = data;
        idData.font = ArialFont;
        idData.alignment = TextAnchor.MiddleCenter;
        idData.horizontalOverflow = HorizontalWrapMode.Overflow;

        idData.GetComponent<RectTransform> ().localPosition = new Vector3 (horizontalPos, verticalPos, 0f);
        idData.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
    }

    public void Exit()
    {
        Application.Quit();
    }
}