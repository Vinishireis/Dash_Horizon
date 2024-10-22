using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class animator_state : MonoBehaviour
{
    public Animator Flight;
    public AudioSource flap;
    void Start()
    {
        Flight = GetComponent<Animator>();
        Invoke("Flap", 5f);
    }
    public void Flap()
    {
        Flight.SetBool("Flap", true);
        Invoke("Timer", 5f);
        flap.Play();
    }
    public void Timer()
    {
        Flight.SetBool("Flap", false);
        Invoke("Flap", 5f);
        flap.Play();
    }

}
