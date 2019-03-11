using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private Vector2Int gridPos;
    private const int gridSize = 10;

    public static int GridSize => gridSize;

    public Vector2Int GridPos => new Vector2Int(
            GridSize * Mathf.RoundToInt(transform.position.x / GridSize),
            GridSize * Mathf.RoundToInt(transform.position.z / GridSize)
            );
}
