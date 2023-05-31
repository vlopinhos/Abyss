using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    private Animator anim;
    public bool lose;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if(!lose)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.enabled = false;
        }
    }
}
