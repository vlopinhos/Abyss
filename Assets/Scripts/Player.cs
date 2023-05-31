using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth = 12;

    private Rigidbody2D rig;
    private Vector2 direction;
    private Vector3 mouseDirection;
    private Animator anim;

    private Spawner[] spawners;
    public int enemiesToKill;

    private void Start()
    {
        health = PlayerManager.playersLife;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawners = FindObjectsOfType<Spawner>();
        for(int i = 0; i < spawners.Length; i++)
        {
            enemiesToKill += spawners[i].maxEnemies;
        }
    }

    private void Update()
    {
        PlayerManager.playersLife = health;

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mouseDirection = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (direction.sqrMagnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);

        }

        

        if (mouseDirection.x > Screen.width * 0.5f)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        if (mouseDirection.x < Screen.width * 0.5f)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            health += 4;
            Destroy(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

    public void getDamage(float damage)
    {
        health -= damage;
        anim.SetTrigger("hurt");
        if (health <= 0)
        {
            anim.SetTrigger("death");
            SceneManager.LoadScene("Lose");
        }
    }   
}
