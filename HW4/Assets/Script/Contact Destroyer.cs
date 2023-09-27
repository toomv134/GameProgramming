using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    public int amount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            ScoreManager.instance.amount += amount;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
