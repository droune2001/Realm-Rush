using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint start = null;
    [SerializeField] Waypoint end = null;

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    private bool isRunning = false;
    private Waypoint searchCenter = null;
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            ColorStartAndEnd();
            BreadthFirstSearch();
            CreatePath();
        }

        return path;
    }

    private void CreatePath()
    {
        Waypoint current = end;
        while (current != start)
        {
            AddToPath(current);
            current = current.exploredFrom;
        }
        AddToPath(current);
        path.Reverse();
    }

    private void AddToPath(Waypoint current)
    {
        path.Add(current);
        current.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        isRunning = true;
        queue.Enqueue(start);
        while (isRunning && queue.Count > 0)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == end)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) return;

        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GridPos + direction;
            if (grid.ContainsKey(explorationCoordinates)) // valid coordinates
            {
                Waypoint neighbor = grid[explorationCoordinates];
                EnqueueNewNeighbor(neighbor);
            }
        }
    }

    private void EnqueueNewNeighbor(Waypoint neighbor)
    {
        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            
        }
        else
        {
            //neighbor.SetTopColor(Color.cyan);
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd()
    {
        //start.SetTopColor(Color.red);
        //end.SetTopColor(Color.blue);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (!grid.ContainsKey(waypoint.GridPos))
            {
                grid.Add(waypoint.GridPos, waypoint);
            }
            else
            {
                Debug.LogWarning("Skipping overlapping block: " + waypoint);
            }
        }
    }
}
