using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SaveGrid : MonoBehaviour
{
    private GridHandler gridHandler;

    void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
    }


    public void Save()
    {
        gridHandler = FindObjectOfType<GridHandler>();
        SaveData saveData = new SaveData();
        saveData.row = gridHandler.rows;
        saveData.col = gridHandler.cols;
        var recc = gridHandler.rectTransforms;

        foreach (var item in recc)
        {
            if (item != null)
            {                
                Debug.Log(item.GetComponent<Image>().color.ToString());
                saveData.colors.Add(item.GetComponent<Image>().color);

            }


        }

        string json = JsonUtility.ToJson(saveData);
        Debug.Log("Saving as JSON: " + json);
    }
}

[Serializable]
public class SaveData
{
    public float row, col;
    public List<Color> colors = new List<Color>();
}
