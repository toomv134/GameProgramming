using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Player : MonoBehaviour
{
    public GameObject Player;

    public float speed;


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Player.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
