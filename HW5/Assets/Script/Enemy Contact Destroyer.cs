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
            if (Life.instance.barrier <= 0)
            {
                Life.instance.amount--;
            }
        }
        else if (other.gameObject.tag == "enemy")
        {

        }
        else if(other.gameObject.tag=="Barrier")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Life.instance.barrier--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
