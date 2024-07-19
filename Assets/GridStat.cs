using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStat : MonoBehaviour
{
    public int x, y;
    private MeshRenderer rend;
    private Color originalColor;
    public Color highlightColor = Color.gray;
    public Color selectedColor = Color.green;
    private bool isHighlighted = false;


    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
        originalColor = rend.material.color;
    }


    private void OnMouseDown()
    {
        if (isHighlighted)
        {
            Debug.Log("Selected " + x + ", " + y);
            rend.material.color = selectedColor;
        }
    }
    public void Highlight()
    {
        isHighlighted = true;
        rend.material.color = highlightColor;
    }

    public void ClearHighlight()
    {
        isHighlighted = false;
        rend.material.color = originalColor;
    }


}
