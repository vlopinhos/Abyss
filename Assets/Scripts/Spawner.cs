using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemySpawner;

    [SerializeField]
    private float timeBtwSpawn = 2f;

    public int maxEnemies = 5;

    private Vector2 position;
    private int enemyCount = 0;

    void Start()
    {
        position = new Vector2(transform.position.x, transform.position.y);
        StartCoroutine(spawnEnemy(timeBtwSpawn, enemySpawner));
    }

    private IEnumerator spawnEnemy(float time, GameObject enemy)
    {
        if(enemyCount < maxEnemies)
        {
            yield return new WaitForSeconds(time);
            GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
            enemyCount++;

            StartCoroutine(spawnEnemy(time, enemy));
        }
    }

}
