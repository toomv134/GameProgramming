using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  EnemyContactDestroyer : MonoBehaviour
{
    public int amount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("hit");
            Destroy(gameObject);
            other.GetComponent<Life>().amount--;
        }
        else if (other.gameObject.tag == "enemy")
        {

        }
        //else if (other.gameObject.tag == "Barrier")
        //{
        //    Destroy(gameObject);
        //    other.GetComponent<Life>().amount--;
        //}
        else
        {
            Destroy(gameObject);
        }
    }
}
