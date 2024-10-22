using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class collider_particle : MonoBehaviour
{
    public GameObject Birdo;
    public Camera Camera;
    public AudioSource bomb;
    public GameObject Final;
    public GameObject Final_Tela;
    public GameObject Tela_pause;
    public string points;
    public TMP_Text Texto_final;
    public void OnParticleCollision(GameObject other)
    {
        if (other.name == "birdo")
        {
            points = Convert.ToString(Math.Round(Final.GetComponent<boosterstar>().pontos));
            bomb.Play();
            Birdo.GetComponent<ParticleSystem>().Play();
            Tela_pause.SetActive(false);
            Texto_final.text = points;
            Final_Tela.SetActive(true);
            Invoke("Pause", 1f);
        }
    }
    void Pause ()
    {
        Cursor.lockState = CursorLockMode.None;
        Birdo.SetActive(false);
    }







}
