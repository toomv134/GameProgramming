using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            //Destroy(other.gameObject);
            other.GetComponent<Life>().amount -= 10;
            ScoreManager.instance.amount ++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
