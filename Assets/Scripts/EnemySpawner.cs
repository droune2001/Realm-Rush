using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,20.0f)]
    [SerializeField] float secondsBetweenSpawns = 2.0f;
    [SerializeField] EnemyMovement enemyPrefab = null;
    [SerializeField] Transform parentTransform = null;
    [SerializeField] Text spawnText = null;
    [SerializeField] AudioClip spawnEnemySfx = null;

    private int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnText.text = spawnCount.ToString();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySfx);
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, parentTransform);
            spawnCount++;
            spawnText.text = spawnCount.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
