using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOutBehaviour : MonoBehaviour
{
    public GameObject gameController;  // Referência ao GameController
    public GameController.TypePlayer pointTo;  // Enum para identificar quem pontuou

    // Método para detectar a colisão
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")  // Verifica se o objeto colidido tem a tag "Ball"
        {
            // Verifica se gameController não é null e se tem o componente GameController
            if (gameController != null && gameController.GetComponent<GameController>() != null)
            {
                // Incrementa os pontos do jogador e reinicia o jogo
                gameController.GetComponent<GameController>().IncrementPoints(pointTo);
                gameController.GetComponent<GameController>().RestartGame();
            }
            else
            {
                Debug.LogError("gameController ou o componente GameController está nulo!");
            }
        }
    }
}
