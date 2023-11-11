using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float runspeed;
    public float rotationSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);


        
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        //if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { transform.Translate(0, 0, -speed * Time.deltaTime); }
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        //if (Input.GetKey(KeyCode.Q)) { transform.Translate(0, -speed * Time.deltaTime, 0); }
        //if (Input.GetKey(KeyCode.E)) { transform.Translate(0, speed * Time.deltaTime, 0); }

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 v = new Vector3 (x, 0, z);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //if (Mathf.Abs(rb.velocity.x) > 30)
            //{
            //    rb.velocity = new Vector3(x, 0, z) * 30;
            //}
            rb.AddRelativeForce(v * runspeed, ForceMode.Force);
        }
        else
        {
            rb.AddRelativeForce(v * speed, ForceMode.Force);
        }
        



    }
}
