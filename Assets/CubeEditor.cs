using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = Waypoint.GridSize;
        Vector2Int gridPos = waypoint.GridPos;
        transform.position = new Vector3(gridSize * gridPos.x, 0.0f, gridSize * gridPos.y);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = (waypoint.GridPos.x).ToString() + "," + (waypoint.GridPos.y).ToString();
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
