using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint1;
    public GameObject shootPoint2;
    public GameObject shootPoint3;
    public ParticleSystem muzzleEffect1;
    public ParticleSystem muzzleEffect2;
    public ParticleSystem muzzleEffect3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(prefab, shootPoint3.transform.position, shootPoint1.transform.rotation);
            muzzleEffect3.Play();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(prefab, shootPoint1.transform.position, shootPoint1.transform.rotation);
            Instantiate(prefab, shootPoint2.transform.position, shootPoint2.transform.rotation);
            muzzleEffect1.Play();
            muzzleEffect2.Play();
        }
    }

}
