using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //public float speed;
    public float rotationSpeed;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float speed = 10;
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.LeftShift)) { speed = speed * 2; }
        if (Input.GetKey(KeyCode.LeftShift) == false) { speed = speed / 2; }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { transform.Translate(0, 0, -speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.Q)) { transform.Translate(0, -speed * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.E)) { transform.Translate(0, speed * Time.deltaTime, 0); }

    }
}
