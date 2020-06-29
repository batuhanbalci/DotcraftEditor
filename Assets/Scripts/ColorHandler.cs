using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHandler : MonoBehaviour
{
    private GridHandler gridHandler;
    private GameObject colorButton, nextColorButton;
    private Color defaultColor = new Color(0.8396226f, 0.8396226f, 0.8396226f);

    void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
        gridHandler.buttonColorIndex = 0;
        colorButton = GameObject.Find("CircularColorButton");
        colorButton.GetComponent<Image>().color = gridHandler.buttonColors[gridHandler.buttonColorIndex];
        nextColorButton = GameObject.Find("CircularColorButtonNext");
        nextColorButton.GetComponent<Image>().color = gridHandler.buttonColors[gridHandler.buttonColorIndex + 1];
    }

    public void PickColor()
    {
        if (gridHandler.buttonColorIndex + 1 == gridHandler.buttonColors.Length)
        {
            gridHandler.buttonColorIndex = 0;
        }
        else
        {
            gridHandler.buttonColorIndex++;
        }

        colorButton.GetComponent<Image>().color = gridHandler.buttonColors[gridHandler.buttonColorIndex];

        if (gridHandler.buttonColorIndex + 1 == gridHandler.buttonColors.Length)
        {
            nextColorButton.GetComponent<Image>().color = gridHandler.buttonColors[0];
        }
        else
        {
            nextColorButton.GetComponent<Image>().color = gridHandler.buttonColors[gridHandler.buttonColorIndex + 1];
        }
    }

    public void ChangeColor()
    {
        if (GetComponent<Image>().color == colorButton.GetComponent<Image>().color)
        {
            GetComponent<Image>().color = defaultColor;

        }
        else
        {
            GetComponent<Image>().color = gridHandler.buttonColors[gridHandler.buttonColorIndex];
        }


    }
}
