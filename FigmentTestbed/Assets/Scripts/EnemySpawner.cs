using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnTime;
    public float randomTime;
    public GameObject[] spawnPoints;
    private float timer;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        timer -= Time.deltaTime;

        if(timer <= 0.0f)
        {
            int index = Random.Range(0, spawnPoints.Length);
            Instantiate(prefab, spawnPoints[index].transform.position, Quaternion.identity);
            ResetTimer();
        }
    }
    void ResetTimer()
    {
        timer = (float)(spawnTime + Random.Range(0, randomTime * 100) / 100.0);
    }
}
