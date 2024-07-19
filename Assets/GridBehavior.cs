using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavior : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public float cellSize = 1;
    public GameObject gridPrefab;
    public Vector3 origin = new Vector3(0, 0, 0);
    public GameObject[,] gridArray;

    private void Awake()
    {
        gridArray = new GameObject[columns, rows];
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 pos = new Vector3(origin.x + cellSize * i, origin.y, origin.z + cellSize * j);
                GameObject obj = Instantiate(gridPrefab, pos, Quaternion.identity);
                obj.transform.SetParent(this.transform);
                obj.GetComponent<GridStat>().x = i;
                obj.GetComponent<GridStat>().y = j;
                gridArray[i, j] = obj;
            }
        }
    }

    public void HighlightArea(int x, int y, int range)
    {
        ClearHighlights();

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                int distance = Mathf.Abs(x - i) + Mathf.Abs(y - j); // Manhattan mesafesi

                if (distance <= range)
                {
                    gridArray[i, j].GetComponent<GridStat>().Highlight();
                }
            }
        }
    }

    public void ClearHighlights()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                gridArray[i, j].GetComponent<GridStat>().ClearHighlight();
            }
        }
    }
}
