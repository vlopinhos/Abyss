using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMenu : MonoBehaviour
{
    private Animator anim;
    private Menu player;
    private Vector2 target;
    private Vector3 previousPosition;
    private AIDestinationSetter destinationSetter;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Menu>();
        previousPosition = transform.position;
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = player.transform;
        
    }
    void Update()
    {
        target = new Vector2(0f, 0f);

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
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        previousPosition = transform.position;

    }

    public void TakeDamageMenu()
    {
        anim.SetTrigger("die");
        Destroy(gameObject, 0.5f);
    }
}
