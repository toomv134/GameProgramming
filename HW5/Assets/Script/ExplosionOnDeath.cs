using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    public GameObject Explode;
    public GameObject selfDestruct;
    public GameObject ExplodePoint;
    private float distance;
    public GameObject Player;
    private void Awake()
    {
        var life=GetComponent<Life>();
        life.onDeath.AddListener(OnDeath);
        Player = GameObject.Find("Player");
        distance = 10;
    }

    void OnDeath()
    {
        if(distance > Vector3.Distance(transform.position, Player.transform.position))
        {
            Instantiate(selfDestruct, ExplodePoint.transform.position, transform.rotation);
            Player.GetComponent<Life>().amount -= 2;
        }
        else
        {
            Instantiate(Explode, ExplodePoint.transform.position, transform.rotation);
        }
    }
}
