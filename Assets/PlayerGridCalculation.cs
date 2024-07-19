using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridCalculation : MonoBehaviour
{
    public int currentRange;
    public int gridX;
    public int gridY;

    public GridBehavior gridBehavior;

    private void Start()
    {
    }

    private void Update()
    {
        AlignToGridPosition();

        if (Input.GetKeyDown(KeyCode.Alpha1)) Range(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Range(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Range(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) Range(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) Range(5);
        if (Input.GetKeyDown(KeyCode.Alpha6)) Range(6);

    }
    void AlignToGridPosition()
    {
        Range(currentRange);
        if (gridX >= 0 && gridX < gridBehavior.columns && gridY >= 0 && gridY < gridBehavior.rows)
        {
            Vector3 gridPosition = new Vector3(
                gridBehavior.origin.x + gridX * gridBehavior.cellSize,
                gridBehavior.origin.y,
                gridBehavior.origin.z + gridY * gridBehavior.cellSize
            );

            transform.position = gridPosition;
        }
        else
        {
            Debug.LogError("Grid coordinates out of range.");
        }
    }



    public void Range(int range)
    {
        currentRange = range;
        HighlightAreaAroundPlayer();
    }

    public void HighlightAreaAroundPlayer()
    {
        int playerX = Mathf.FloorToInt((transform.position.x - gridBehavior.origin.x) / gridBehavior.cellSize);
        int playerY = Mathf.FloorToInt((transform.position.z - gridBehavior.origin.z) / gridBehavior.cellSize);

        gridBehavior.HighlightArea(playerX, playerY, currentRange);
    }
}
