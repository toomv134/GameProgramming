using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int amount;
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

    private void Update()
    {
        if(amount > 10)
        {
            SceneManager.LoadScene("Win Scene");
        }
    }
}
