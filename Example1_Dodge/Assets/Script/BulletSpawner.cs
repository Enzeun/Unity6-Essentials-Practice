using Sirenix.OdinInspector;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    
    [SerializeField]
    private GameObject bulletPrefab;
    private float spawnRateMin = 0.5f;
    private float spawnRateMax = 3f;
    
    private Transform target;
    [HorizontalGroup]
    [SerializeField]
    [ShowInInspector]
    private float spawnRate;
    [HorizontalGroup]
    [ShowInInspector]
    private float timeAfterSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindFirstObjectByType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;

            SpawnBullet();

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    [Button]
    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.LookAt(target);
    }
}

