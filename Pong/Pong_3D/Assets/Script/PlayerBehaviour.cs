using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypePlayerController { Keyboard, Mouse, TouchCel, IAController }
public enum TypePlayer { PlayerOne, PlayerTwo }

public class PlayerBehaviour : MonoBehaviour
{
    public TypePlayer typeplayer;
    public TypePlayerController typePlayerController;
    public GameObject GameController;

    private bool playerOne;
    private bool iaController;

    public float speedy = 10f;
    public float top = 7.9f;
    public float bottom = -5.8f;

    private Vector3 posInitial;
    // Start is called before the first frame update
    void Start()
    {
        posInitial = transform.position;   
    }

    public void SetPlayer(TypePlayer player)
    {
        this.typeplayer = player;
        this.playerOne = (player == TypePlayer.PlayerOne); // Define se é o PlayerOne
    }

    public void SetStartPosition()
    {
        transform.position = posInitial;
    }
    public TypePlayer GetPlayer()
    {
        return this.typeplayer;
    }

    public void SetPlayerController(TypePlayerController controller)
    {
        typePlayerController = controller;
    }

    public TypePlayerController GetPlayerController()
    {
        return typePlayerController;
    }

    public void SetIAController(bool ia)  // Alterado o nome para descrever melhor a função
    {
        this.playerOne = false;
        this.iaController = ia;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GetComponent<GameController>().GetGameState() == global::GameController.TypeGameState.Play)
        {
            Vector3 position = transform.position;
                if (this.typePlayerController == TypePlayerController.Keyboard && this.playerOne)
        {
            // Controle pelo teclado
            float moveVertical = Input.GetAxis("Vertical");
            if (moveVertical != 0)
            {
                float speedTemp = this.speedy * Time.deltaTime * moveVertical;
                position.y = Mathf.Clamp(position.y + speedTemp, this.bottom, this.top);
                transform.position = position;
            }
        }

        if (this.typePlayerController == TypePlayerController.Mouse)
        {
            // Controle pelo Mouse
            var mousePos = Input.mousePosition;
            mousePos.z = 18;
            Vector3 raw = Camera.main.ScreenToWorldPoint(mousePos);

            position.y = Mathf.Clamp(raw.y, this.bottom, this.top);
            transform.position = position;
        }

        if (this.typePlayerController == TypePlayerController.IAController)
        {
            GameObject ball = GameObject.FindWithTag("Ball");
            if (ball)
            {
                Vector3 origin = transform.position;
                Vector3 destiny = new Vector3(origin.x, ball.transform.position.y, origin.z);
                destiny = Vector3.Lerp(origin, destiny, 0.5f);
                destiny.y = Mathf.Clamp(destiny.y, this.bottom, this.top);
                transform.position = destiny;
            }
        }

        if (this.typePlayerController == TypePlayerController.TouchCel)
        {
            // Controle para celular (Touch)
         }
        }
    }
}
