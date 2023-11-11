using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance;

    public Vector3 Playerpos;
    public List<Enemy> enemies;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //print("Duplicated ScoreManager, ignoring this one");
            Debug.Log("Duplicated ScoreManager, ignoring this one", gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
