using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Vector3 startPosition;
    public float initialSpeed = 4f;
    public float constantSpeed = 30f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        LaunchBall(); // Lan�a a bola assim que o jogo come�a
    }

    // Mant�m a velocidade constante
    void Update()
    {
        // Impede que a bola desacelere mantendo sua velocidade constante
        if (rb.velocity.magnitude != constantSpeed)
        {
            rb.velocity = constantSpeed * rb.velocity.normalized;
        }
    }

    // Lan�amento da bola
    public void LaunchBall()
    {
        // Lan�a a bola numa dire��o aleat�ria no eixo X ou Y com a velocidade inicial
        float randomDirectionX = Random.Range(0, 2) == 0 ? -1f : 1f; // Dire��o aleat�ria no eixo X
        float randomDirectionY = Random.Range(-0.5f, 0.5f); // Pequena varia��o no eixo Y
        rb.velocity = new Vector3(randomDirectionX, randomDirectionY, 0).normalized * initialSpeed;
    }

    // Reseta a posi��o inicial e a velocidade da bola
    public void SetStartPosition()
    {
        rb.velocity = Vector3.zero; // Para a bola antes de reposicion�-la
        transform.position = startPosition; // Volta para o centro
    }
}
