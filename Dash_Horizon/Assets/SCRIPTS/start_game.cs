using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class start_game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Sky_Game");
        SceneManager.UnloadSceneAsync("LowPolyclouds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
