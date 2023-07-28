using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] powerUpPrefabs;
    [SerializeField] GameObject debris;
    private int waveNumber;
    private bool spawnDebris, spawnPowerUp, spawnHeart, spawnRight;
    private float[] spawnXPos = { 21.0f, -21.0f };
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 1;
        spawnDebris = true;
        spawnPowerUp = true;
        spawnRight = true;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        int debrisCount = FindObjectsOfType<Debris>().Length;
        
        if(enemyCount == 0 && gameManager.isGameActive)
        {
            for(int i = 0; i < waveNumber; i++)
            {
                SpawnHostileObjects(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
            }
            waveNumber++;
            spawnHeart = true;
        }

        if(debrisCount == 0 && spawnDebris && gameManager.isGameActive)
        {
            spawnDebris = false;
            StartCoroutine(DebrisCooldown(5, Random.Range(1,4)));
        }

        if(spawnPowerUp && waveNumber > 2 && gameManager.isGameActive)
        {
            spawnPowerUp = false;
            SpawnPowerUps(Random.Range(1, powerUpPrefabs.Length));
            StartCoroutine(PowerUpCooldown());
        }
    }

    void SpawnHostileObjects(GameObject hostileObject) 
    {
        Vector3 spawnPos;
        if (spawnRight)
        {
            spawnPos = new Vector3(spawnXPos[0], 0.6f, Random.Range(-7.0f, 7.0f));
            spawnRight = false;
        }
        else
        {
            spawnPos = new Vector3(spawnXPos[1], 0.6f, Random.Range(-7.0f, 7.0f));
            spawnRight = true;
        }
        SpawnObject(hostileObject, spawnPos);

    }

    void SpawnPowerUps(int powerup)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-18.0f, 18.0f), 0.15f, Random.Range(-7.0f, 7.0f));
        SpawnObject(powerUpPrefabs[powerup], spawnPos);
    }

    IEnumerator DebrisCooldown(int waiTime, int spawnCount)
    {
        yield return new WaitForSeconds(waiTime);
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnHostileObjects(debris);
        }
        spawnDebris = true;
    }

    IEnumerator PowerUpCooldown()
    {
        yield return new WaitForSeconds(15);

        spawnPowerUp = true;
    }

    void SpawnObject(GameObject obj, Vector3 position)
    {
        Instantiate(obj, position, obj.transform.rotation);
    }
}
