using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab = null;
    [SerializeField] int maxTowers = 5;
    [SerializeField] Transform towerParentTransform = null;

    Queue<Tower> towerQueue = new Queue<Tower>();

    
    public void AddTower(Waypoint baseWaypoint)
    {
        int currentTowersCount = towerQueue.Count;
        if (currentTowersCount < maxTowers)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var t = towerQueue.Dequeue();
        t.baseWaypoint.hasTower = false;
        // TODO: set hasTower = false to previous Waypoint.
        t.transform.position = baseWaypoint.transform.position;
        t.baseWaypoint = baseWaypoint;
        baseWaypoint.hasTower = true;
        towerQueue.Enqueue(t);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var t = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towerParentTransform);
        t.baseWaypoint = baseWaypoint;
        baseWaypoint.hasTower = true;
        towerQueue.Enqueue(t);
    }
}
