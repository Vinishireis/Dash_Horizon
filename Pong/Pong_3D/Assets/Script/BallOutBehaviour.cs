using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOutBehaviour : MonoBehaviour
{
    public GameObject gameController;  // Refer�ncia ao GameController
    public GameController.TypePlayer pointTo;  // Enum para identificar quem pontuou

    // M�todo para detectar a colis�o
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")  // Verifica se o objeto colidido tem a tag "Ball"
        {
            // Verifica se gameController n�o � null e se tem o componente GameController
            if (gameController != null && gameController.GetComponent<GameController>() != null)
            {
                // Incrementa os pontos do jogador e reinicia o jogo
                gameController.GetComponent<GameController>().IncrementPoints(pointTo);
                gameController.GetComponent<GameController>().RestartGame();
            }
            else
            {
                Debug.LogError("gameController ou o componente GameController est� nulo!");
            }
        }
    }
}
