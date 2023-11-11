using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public static Life instance;
    public float amount;
    public float barrier;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Life error");
        }
        amount = 10;
        barrier = 4;
    }
    private void Start()
    {
        
    }
}
