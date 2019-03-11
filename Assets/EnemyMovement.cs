using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        print("Starting patrol");
        foreach(Waypoint waypoint in path)
        {
            print("Visiting waypoint: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1.0f);
        }
        print("Ending patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
