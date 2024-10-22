using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public bool Paused = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            Paused = true;
            GetComponent<TextMeshProUGUI>().enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 1.0f;
            Paused = false;
            GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
}
