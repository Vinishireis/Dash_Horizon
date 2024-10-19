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
        LaunchBall(); // Lança a bola assim que o jogo começa
    }

    // Mantém a velocidade constante
    void Update()
    {
        // Impede que a bola desacelere mantendo sua velocidade constante
        if (rb.velocity.magnitude != constantSpeed)
        {
            rb.velocity = constantSpeed * rb.velocity.normalized;
        }
    }

    // Lançamento da bola
    public void LaunchBall()
    {
        // Lança a bola numa direção aleatória no eixo X ou Y com a velocidade inicial
        float randomDirectionX = Random.Range(0, 2) == 0 ? -1f : 1f; // Direção aleatória no eixo X
        float randomDirectionY = Random.Range(-0.5f, 0.5f); // Pequena variação no eixo Y
        rb.velocity = new Vector3(randomDirectionX, randomDirectionY, 0).normalized * initialSpeed;
    }

    // Reseta a posição inicial e a velocidade da bola
    public void SetStartPosition()
    {
        rb.velocity = Vector3.zero; // Para a bola antes de reposicioná-la
        transform.position = startPosition; // Volta para o centro
    }
}
