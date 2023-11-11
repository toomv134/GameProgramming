using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int amount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            print("Duplicated ScoreManager, ignoring this one");
        }
    }
}
