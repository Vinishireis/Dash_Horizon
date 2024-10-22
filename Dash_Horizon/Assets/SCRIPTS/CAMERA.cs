using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CAMERA : MonoBehaviour
{


    public float Mousen;

    public float CamAxisX;
    public float CamAxisY;


    public Camera Can;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {


    }
}

