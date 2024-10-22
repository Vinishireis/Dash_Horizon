using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class boosterstar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Birdo;
    public Camera Camera;
    public TMP_Text time_alive;
    
    public float pontos;
    public AudioSource ding;
    void Update()
    {
        float time = Time.deltaTime;
        pontos += time;
        time_alive.text = Convert.ToString(Math.Round(pontos));
        
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.name == "birdo")
        {

            pontos += 100;
            ding.Play();
        }
    }
}
