using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class flight : MonoBehaviour
{
    public bool Stop;
    public Collider player;
    public Rigidbody rb;
    public float velocidade;
    public float turn_vel;
    public Camera cam;
    public Transform corpo;
    public GameObject particulas;
    public GameObject bombas;
    public GameObject estrelas;
    GameObject p1;
    GameObject p2;
    GameObject b1;
    GameObject b2;
    GameObject e1;
    GameObject e2;
    Quaternion flight_turn_dir;
    public float AxisX;
    public float AxisY;
    public float AxisZ;
    Quaternion base_angle;
    public float return_speed;
    public TMP_Text time_alive;
    public Vector2 pos;
    public GameObject Pause_Texto;
    public float acelerator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("Insta", 3f);
        Invoke("save_Rotation", 1f);
        Cursor.lockState = CursorLockMode.Locked;
        
    }


    void Update()
    {
        Stop = Pause_Texto.GetComponent<Pause>().Paused;
        if (Stop == false)
        {
            AxisX += (Input.GetAxis("Mouse Y"));
            AxisY += (Input.GetAxis("Mouse X"));
            AxisZ += (Input.GetAxis("Mouse X"));
            AxisX = Mathf.Clamp(AxisX, -90, 90);
            AxisY = Mathf.Clamp(-180, AxisY, 180);

            flight_turn_dir.eulerAngles = (new Vector3(AxisX, AxisY,AxisZ) * turn_vel);
            rb.velocity += (cam.transform.forward * velocidade);

            if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
            {
                corpo.transform.rotation = (flight_turn_dir);
                cam.transform.forward -= corpo.transform.forward * 0.5f;
            }
            else
            {
                corpo.transform.rotation = Quaternion.RotateTowards(corpo.transform.rotation, base_angle, return_speed);
            }
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
    public void Insta()
    {
        Destroy(e2);
        Destroy(b2);
        Destroy(p2);
        e1 = Instantiate(estrelas, corpo.position, estrelas.transform.rotation);
        b1 = Instantiate(bombas, corpo.position, bombas.transform.rotation);
        p1 = Instantiate(particulas, corpo.position, particulas.transform.rotation);
        e1.GetComponent<boosterstar>().enabled = false;
        Invoke("Insta2", acelerator);
        
    }
    public void Insta2()
    {
        Destroy(e1);
        Destroy(p1);
        Destroy(b1);
        e2 = Instantiate(estrelas, corpo.position, estrelas.transform.rotation);
        p2 = Instantiate(particulas, corpo.position, particulas.transform.rotation);
        b2 = Instantiate(bombas, corpo.position, bombas.transform.rotation);
        e2.GetComponent<boosterstar>().enabled = false;
        Invoke("Insta", acelerator);
        
    }
    public void save_Rotation()
    {
        base_angle = corpo.rotation;
    }
}
