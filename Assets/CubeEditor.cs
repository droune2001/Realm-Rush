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
        Vector2Int gridPos = waypoint.GridPos;
        transform.position = new Vector3(gridPos.x, 0.0f, gridPos.y);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = (waypoint.GridPos.x / Waypoint.GridSize).ToString() + "," + (waypoint.GridPos.y / Waypoint.GridSize).ToString();
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
