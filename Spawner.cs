using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector2 spawnPoint;
    public GameObject asteroid;
    public GameObject coin;
    
    public float timeTillNextAsteroidSpawn, timeTillNextCoinSpawn;

    public float minY, maxY;
    public float timerForCoin, timerForAsteroid;
    public float randomScale;

    public bool isPause;

    void Start()
    {
        isPause = false;
        timeTillNextAsteroidSpawn = 0.2f;
        timeTillNextCoinSpawn = 2;
        timerForCoin = 0;
        timerForAsteroid = 0;
        spawnPoint.x = 4;
        minY = -0.8f; maxY = 0.8f;

    }

    // Update is called once per frame
    void Update()
    {
        timerForCoin += Time.deltaTime; timerForAsteroid += Time.deltaTime;
        if (timerForAsteroid >= timeTillNextAsteroidSpawn)
            SpawnAsteroid();
        if (timerForCoin >= timeTillNextCoinSpawn)
            SpawnCoin();
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SpawnAsteroid()
    {
        timerForAsteroid = 0;
        spawnPoint.y = Random.Range(minY, maxY);
        AsteroidSize();
        Instantiate(asteroid, spawnPoint, Quaternion.identity);
    }

    void SpawnCoin()
    {
        timerForCoin = 0;
        spawnPoint.y = Random.Range(minY, maxY);
        coinSize();
        Instantiate(coin, spawnPoint, Quaternion.identity);
    }

    void AsteroidSize()
    {
        randomScale = Random.Range(1f, 2.5f);
        asteroid.gameObject.transform.localScale = new Vector2(0.5f * randomScale, 0.5f * randomScale);
    }

    void coinSize()
    {
        randomScale = Random.Range(0.5f, 1.5f);
        coin.gameObject.transform.localScale = new Vector2(0.5f * randomScale, 0.5f * randomScale);
    }
}
