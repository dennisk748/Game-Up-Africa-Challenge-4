using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject powerIcon;
    private PlayerController playerController;
    //[SerializeField] private float repeatRate;
    [SerializeField] private float iconRepeatRate;
    //[SerializeField] private float delay;
    [SerializeField] private float iconDelay;

    private float spawnRange = 9f;
    private int spawnCount = 1;
    private int enemyCount;

    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnEnemyWave(spawnCount);
        //InvokeRepeating("Spawn", delay, repeatRate);
        InvokeRepeating("SpawnPowerIcon", iconDelay, Random.Range(iconDelay,iconRepeatRate));
        
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && playerController.isGameOver == false)
        {
            Debug.Log("First wave complete");
            SpawnEnemyWave(spawnCount);
        }
    }

    void SpawnEnemyWave(int numberOfEnemies)
    {
        spawnCount++;
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(Enemy, new Vector3(Random.Range(-spawnRange, spawnRange), 0,
            Random.Range(-spawnRange, spawnRange)), Enemy.transform.rotation);
        }
    }



    /**void Spawn()
    {
        Instantiate(Enemy, new Vector3(Random.Range(-spawnRange,spawnRange),0,
            Random.Range(-spawnRange, spawnRange)),Enemy.transform.rotation);
    }**/

    void SpawnPowerIcon()
    {
        if(playerController.isGameOver == false)
        {
            Instantiate(powerIcon, new Vector3(Random.Range(-spawnRange, spawnRange), 0,
            Random.Range(-spawnRange, spawnRange)), powerIcon.transform.rotation);
        }
    }
}
