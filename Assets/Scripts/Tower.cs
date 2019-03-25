using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters
    [SerializeField] Transform objectToPan = null; // tower top
    [SerializeField] float attackRange = 30.0f;
    [SerializeField] ParticleSystem projectileParticle = null;
    
    // State
    Transform targetEnemy = null;
    public Waypoint baseWaypoint = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) return;

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDamage enemy in sceneEnemies)
        {
            if (!enemy.isDead)
            {
                closestEnemy = GetClosest(closestEnemy.transform, enemy.transform);
            }
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transform1, Transform transform2)
    {
        float dist1 = Vector3.Distance(transform.position, transform1.position);
        float dist2 = Vector3.Distance(transform.position, transform2.position);
        //if (dist1 - Mathf.Epsilon <= dist2)
        if (dist1 - 1.0f <= dist2)
        {
            return transform1;
        }
        else
        {
            return transform2;
        }
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool doShoot)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = doShoot;
    }
}
