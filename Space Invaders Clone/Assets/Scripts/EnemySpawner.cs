using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform shotSpawn;
    public float spawnRate;
    public float nextSpawn;
    private Transform spawner;

    
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<Transform>();
    }
    public int contatore = 0;
    public int childCount;

    // Update is called once per frame
    void Update()
    {
        if (spawner.childCount < 5)
        {
            childCount = spawner.childCount;

            if (Random.Range(0, 10) > spawnRate && Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                Instantiate(enemy, shotSpawn.position, shotSpawn.rotation);
                contatore++;
            }
        }
    }
}
