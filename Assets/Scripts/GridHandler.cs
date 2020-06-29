using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    #region Constraints
    private const byte minRowSize = 3;
    private const byte maxRowSize = 7;
    private const byte minColSize = 3;
    private const byte maxColSize = 7;
    #endregion

    public float rows { get; private set; } = 3;
    public float cols { get; private set; } = 6;

    
    public RectTransform[,] rectTransforms { get; private set; } = new RectTransform[maxColSize, maxRowSize];
    private GameObject mainPanel;
    public Color[] buttonColors = { Color.white, Color.blue, Color.red };
    public int buttonColorIndex = 0;

    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        mainPanel = GameObject.Find("MainPanel");
        GameObject referredCircularButton = GetReferencedCircularButton();

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject grid = (GameObject)Instantiate(referredCircularButton, mainPanel.transform);
                RectTransform rect = grid.GetComponent<RectTransform>();
                rectTransforms[j, i] = rect;
            }
        }
        RearrangeGrid();
        Destroy(referredCircularButton);
    }

    private void RearrangeGrid()
    {
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                rectTransforms[j, i].localScale = new Vector3(0.5f, 0.5f, 0f);
                rectTransforms[j, i].anchorMin = new Vector2(i / cols, j / rows);
                rectTransforms[j, i].anchorMax = new Vector2(i / cols + 1 / cols, j / rows + 1 / rows);
                rectTransforms[j, i].offsetMin = new Vector2(i / cols, j / rows);
                rectTransforms[j, i].offsetMax = new Vector2(i / cols + 1 / cols, j / rows + 1 / rows);
            }
        }
    }

    private void ColumnOrder(ResizeButtonHandler.ResizeDirection resizeDirection)
    {
        GameObject referredCircularButton = GetReferencedCircularButton();

        for (int i = 0; i < rows; i++)
        {
            if (resizeDirection == ResizeButtonHandler.ResizeDirection.Left)
            {
                Destroy(rectTransforms[i, (int)cols - 1].gameObject);
                rectTransforms[i, (int)cols - 1] = null;
            }
            else
            {
                GameObject grid = (GameObject)Instantiate(referredCircularButton, mainPanel.transform);
                RectTransform rect = grid.GetComponent<RectTransform>();
                rectTransforms[i, (int)cols] = rect;
            }
        }
        Destroy(referredCircularButton);
    }

    private void RowOrder(ResizeButtonHandler.ResizeDirection resizeDirection)
    {
        GameObject referredCircularButton = GetReferencedCircularButton();

        for (int i = 0; i < cols; i++)
        {
            if (resizeDirection == ResizeButtonHandler.ResizeDirection.Down)
            {
                Destroy(rectTransforms[(int)rows - 1, i].gameObject);
                rectTransforms[(int)rows - 1, i] = null;
            }
            else
            {
                GameObject grid = (GameObject)Instantiate(referredCircularButton, mainPanel.transform);
                RectTransform rect = grid.GetComponent<RectTransform>();
                rectTransforms[(int)rows, i] = rect;
            }
        }
        Destroy(referredCircularButton);
    }

    public void ChangeGridSize(ResizeButtonHandler.ResizeDirection resizeDirection)
    {
        switch (resizeDirection)
        {
            case ResizeButtonHandler.ResizeDirection.Left:
                if (cols > minColSize)
                {
                    ColumnOrder(resizeDirection);
                    cols--;
                    RearrangeGrid();
                }
                break;
            case ResizeButtonHandler.ResizeDirection.Right:
                if (cols < maxColSize)
                {
                    ColumnOrder(resizeDirection);
                    cols++;
                    RearrangeGrid();
                }
                break;
            case ResizeButtonHandler.ResizeDirection.Up:
                if (rows < maxRowSize)
                {
                    RowOrder(resizeDirection);
                    rows++;
                    RearrangeGrid();
                }
                break;
            case ResizeButtonHandler.ResizeDirection.Down:
                if (rows > minRowSize)
                {
                    RowOrder(resizeDirection);
                    rows--;
                    RearrangeGrid();
                }
                break;
            default:
                break;
        }

    }

    public GameObject GetReferencedCircularButton()
    {
        return Instantiate(Resources.Load("Prefabs/CircularButton")) as GameObject;
    }
}
