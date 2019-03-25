using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public bool isDead = false;

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab = null;
    [SerializeField] ParticleSystem deathParticlePrefab = null;

    [SerializeField] AudioClip enemyHitSfx = null;
    [SerializeField] AudioClip enemyDeathSfx = null;

    private AudioSource audioSource = null;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        isDead = true; // for the towers to stop targetting it
        //transform.Find("Body").GetComponent<MeshRenderer>().enabled = false; // hide object
        var deathParticleRef = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathParticleRef.Play();
        float remainingTime = deathParticleRef.main.duration;
        Destroy(deathParticleRef.gameObject, remainingTime);

        AudioSource.PlayClipAtPoint(enemyDeathSfx, Camera.main.transform.position);

        Destroy(gameObject); // destroy immediately
    }

    void ProcessHit()
    {
        audioSource.PlayOneShot(enemyHitSfx);
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }
}
