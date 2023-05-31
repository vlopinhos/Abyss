using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float attack;
    public float cooldown = 1f;
    public string nextScene;
    public float dropChance = 0.3f;
    public GameObject heartPrefab;

    private Animator anim;
    private Player player;
    private Vector2 target;
    private float nextAttack;
    private float distance;
    private Vector3 previousPosition;
    private AIDestinationSetter destinationSetter;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        previousPosition = transform.position;
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = player.transform;
    }

    void Update()
    {
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        
        distance = Vector2.Distance(transform.position, target);

        if(distance < 0.8f && Time.time > nextAttack)
        {
            AttackPlayer(attack);
            
            nextAttack = Time.time + cooldown;
        }

        if (transform.position != previousPosition)
        {
            anim.SetBool("isWalking", true);
            float difference = transform.position.x - previousPosition.x;

            if (difference > 0)
            {
                transform.eulerAngles = new Vector2(0f, 0f);
            }
            else if (difference < 0)
            {
                transform.eulerAngles = new Vector2(0f, 180f);
            }
        } else
        {
            anim.SetBool("isWalking", false);
        }

        previousPosition = transform.position;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("hurt");
        if (health <= 0)
        {
            if (Random.value <= dropChance)
            {   
                Instantiate(heartPrefab, transform.position, Quaternion.identity);
            }
            player.enemiesToKill--;
            GetComponent<AIPath>().maxSpeed = 0;
            anim.SetTrigger("die");
            Destroy(gameObject, 0.5f);
        }
    }

    public void AttackPlayer(float attack)
    {
        anim.SetTrigger("attack");
        player.getDamage(attack);
    }
}
