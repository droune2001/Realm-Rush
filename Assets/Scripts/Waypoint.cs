using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom = null;
    public bool isPlaceable = true;

    private Vector2Int gridPos;
    private const int gridSize = 10;

    public static int GridSize => gridSize;

    public Vector2Int GridPos => new Vector2Int(
            Mathf.RoundToInt(transform.position.x / GridSize),
            Mathf.RoundToInt(transform.position.z / GridSize)
    );

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                print(gameObject.name);
            }
            else
            {
                print(gameObject.name + " IS NOT PLACEABLE");
            }
        }
    }

    //public void SetTopColor(Color color)
    //{
    //    Material m = transform.Find("Top").GetComponent<MeshRenderer>().material;
    //    m.color = color;
    //}
}
