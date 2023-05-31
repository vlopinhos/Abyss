using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject lostMemory;

    private GameObject boss;
    private GameObject lost;
    private Player player;
    private bool readyToSpawn = true;

    private int count = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (player.enemiesToKill == 0)
        {
            if(readyToSpawn)
            {
                boss = Instantiate(bossPrefab, new Vector2(0f, 0f), Quaternion.identity);
                readyToSpawn = false;
            }
        }

        if(boss != null && boss.GetComponent<Enemy>().health == 0)
        {
            if(count == 0)
            {
                lost = Instantiate(lostMemory, new Vector2(boss.transform.position.x, boss.transform.position.y), Quaternion.identity);
                count++;
                lost.GetComponent<Item>().setNextScene(boss.GetComponent<Enemy>().nextScene);
            }
        }
    }
}
