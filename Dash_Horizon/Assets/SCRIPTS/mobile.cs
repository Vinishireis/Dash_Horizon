using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class mobile : MonoBehaviour
{
    float width;
    float height;
    public float turn_vel;
    public Transform corpo;
    public float velocidade;
    public Quaternion flight_turn_dir;
    Rigidbody rb;
    public Camera cam;
    public Vector2 pos;
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        rb.velocity = (cam.transform.forward * velocidade);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            pos += touch.deltaPosition;


            flight_turn_dir.eulerAngles = (new Vector3(pos.y, pos.x, +pos.x) * turn_vel);

            
            corpo.transform.rotation = (flight_turn_dir);
            cam.transform.forward -= corpo.transform.forward * 0.5f;
            

        }

        

    }
}