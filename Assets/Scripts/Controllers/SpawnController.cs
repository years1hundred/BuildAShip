using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public int amountOfShips;
    public int shipCap;
    public float spawnTime;
    public float spawnCountdown;
    public float minSpawnRadius;
    public float maxSpawnRadius;

    public GameObject enemy;
    public GameObject player;


    public void Start()
    {
        spawnCountdown = spawnTime;
    }


    void Update()
    {
        if (amountOfShips < shipCap)
        {
            if (spawnCountdown > 0)
            {
                spawnCountdown -= Time.deltaTime;
            }
            else
            {
                SpawnShip();
                amountOfShips++;
                spawnCountdown = spawnTime;
            }
        }
    }


    public void SpawnShip()
    {
        var spawnVariable = GetSpawnPoint(minSpawnRadius, maxSpawnRadius);
        var spawnPosition = new Vector3(spawnVariable.x, 1, spawnVariable.y) + player.transform.position;
        Instantiate(enemy, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
    }


    public static Vector2 GetSpawnPoint(float minRadius, float maxRadius)
    {
        var spawnVariable = Random.insideUnitCircle * 20;
        return spawnVariable.normalized * minRadius + spawnVariable * (maxRadius - minRadius);
    }
}
