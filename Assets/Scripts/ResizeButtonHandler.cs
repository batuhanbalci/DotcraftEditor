using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeButtonHandler : MonoBehaviour
{
    private GridHandler gridHandler;

    private void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
    }

    public enum ResizeDirection : byte
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3
    }

    public void Resize()
    {
        ResizeDirection resizeDirection;
        if (gameObject.name == "Left")
        {
            resizeDirection = ResizeDirection.Left;
        }
        else if (gameObject.name == "Right")
        {
            resizeDirection = ResizeDirection.Right;
        }
        else if (gameObject.name == "Up")
        {
            resizeDirection = ResizeDirection.Up;
        }
        else
        {
            resizeDirection = ResizeDirection.Down;
        }
        gridHandler.ChangeGridSize(resizeDirection);
    }
}
