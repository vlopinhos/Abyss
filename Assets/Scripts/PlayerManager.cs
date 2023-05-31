using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static float playersLife = 12;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
