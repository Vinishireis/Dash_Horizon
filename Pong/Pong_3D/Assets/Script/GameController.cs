using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Certifique-se de importar o TextMeshPro namespace

public class GameController : MonoBehaviour
{
    // Enum para o tipo de jogador
    public enum TypePlayer { PlayerVSPlayer, PlayerVSCPU };

    // Enum para o tipo de controle do jogador
    public enum TypePlayerController { Keyboard, Mouse, TouchCel, IAController };

    // Enum para o estado do jogo
    public enum TypeGameState { Pause, Stop, GameOver, Win, Play };


    //GameObject gameController
    public GameObject gameController;

    // Propriedades de Controle do Jogo
    public int matches; // Total de Partidas
    public int player1Point; // Pontos do Jogador 1
    public int player2Point; // Pontos do Jogador 2
    public TypePlayer playerMode; // Tipo do Jogo Player VS Player ou Player VS CPU
    public TypeGameState gameState; // Estado do jogo: Pause, Play, Stop, Game Over
    /*----------------------------------------------------------------------------*/

    // Componentes do Jogo
    public GameObject paddle1; // Raquete 1 
    public GameObject paddle2; // Raquete 2
    public GameObject Ball; // Bola do Jogo
    public RectTransform panelMainMenu; //Painel que representa o menu inicial do jogo START/EXIT
    public RectTransform panelGameMode; // Painel que representa o menu de seleção de modo de jogo
    public RectTransform panelGameOver; // Painel que representa o menu de Fim de Jogo
    /*----------------------------------------------------------------------------*/

    // Componentes da Tela (TextMeshProUGUI)
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI playerOneText;
    public TextMeshProUGUI playerTwoText;
    public TextMeshProUGUI ballText;
    public TextMeshProUGUI maxPointText;
    /*----------------------------------------------------------------------------*/

    // Inicialização
    void Start()
    {
        // Iniciar diretamente no modo de seleção de jogo
        this.ShowMainMenu();
    }

    // Atualização por frame
    void Update()
    {
        playerOneText.text = "Player One: " + player1Point.ToString();
        playerTwoText.text = "Player Two: " + player2Point.ToString();
    }

    public void ShowMainMenu()
    {
        gameState = TypeGameState.Stop;
        panelMainMenu.gameObject.SetActive(true);  // Mostra o menu principal (Start/Exit)
        panelGameMode.gameObject.SetActive(false); // Esconde o menu de seleção de modo de jogo
        panelGameOver.gameObject.SetActive(false); // Esconde o menu de fim de jogo
    }


    public void ReturnToMainMenu()
    {
        // Reseta o estado do jogo e exibe o menu principal
        player1Point = 0;
        player2Point = 0;
        gameState = TypeGameState.Stop;

        // Esconde painéis desnecessários
        panelGameMode.gameObject.SetActive(true);
        panelGameOver.gameObject.SetActive(false);
    }

    public TypeGameState GetGameState()
    {
        return gameState;
    }

    public void StartGame(TypePlayer mode, TypePlayerController p1)
    {
        // Texto na Tela
        maxPointText.text = "Matches: " + matches.ToString();
        playerOneText.text = "Player One: 0";
        playerTwoText.text = "Player Two: 0";

        // Inicia os parâmetros do Jogo
        playerMode = mode;

        // Esconde os Menus
        panelGameMode.gameObject.SetActive(false); // Esconde o menu de seleção de modo de jogo
        panelGameOver.gameObject.SetActive(false); // Esconde o menu de fim de jogo

        // Zera os Pontos
        player1Point = 0;
        player2Point = 0;

        // Define os controles do player 1
        paddle1.GetComponent<PlayerBehaviour>().SetPlayer(global::TypePlayer.PlayerOne);
        paddle1.GetComponent<PlayerBehaviour>().SetPlayerController(global::TypePlayerController.Mouse);

        // Define os Controles do player 2
        paddle2.GetComponent<PlayerBehaviour>().SetPlayer(global::TypePlayer.PlayerTwo);

        if (mode == TypePlayer.PlayerVSCPU)
        {
            paddle2.GetComponent<PlayerBehaviour>().SetPlayerController(global::TypePlayerController.IAController);
        }
        else
        {
            paddle2.GetComponent<PlayerBehaviour>().SetPlayerController(global::TypePlayerController.Keyboard);
        }

        // Inicia a bola
        StartCoroutine(StartBall());
    }
    private IEnumerator StartBall()
    {

        int i = 0;
        ballText.enabled = true;
        for (i = 5; i > 0; i--)
        {
            ballText.text = i.ToString();
            yield return new WaitForSeconds(1.5f);
        }
        ballText.text = "Start";
        yield return new WaitForSeconds(1.5f);
        ballText.enabled = false;
        gameState = TypeGameState.Play;
        //Lançamento da Bola
        Ball.GetComponent<BallBehaviour>().LaunchBall();
    }

    // Método para selecionar o modo de jogo
    public void MenuSelect(int op)
    {
        Debug.Log("Opção selecionada: " + op); // Depuração para verificar a opção selecionada

        if (op == 1) // Start - Abre o menu de seleção de modo de jogo
        {
            ShowGameModeMenu(); // Mostra o painel para escolher entre Player vs CPU e Player vs Player
        }
        else if (op == 2) // Exit - Sai do jogo
        {
            Application.Quit(); // Fecha o jogo
        }
    }

    // Função para exibir o menu de seleção de modo de jogo
    public void ShowGameModeMenu()
        {
            panelGameMode.gameObject.SetActive(true);   // Mostra o painel de seleção de modo de jogo
            panelMainMenu.gameObject.SetActive(false);  // Esconde o painel principal (Start/Exit)
            panelGameOver.gameObject.SetActive(false);  // Esconde outros menus
        }

    // Função que será chamada após escolher o modo de jogo
    public void StartGameMode(int modeOption)
    {
        if (modeOption == 1) // Player vs CPU
        {
            StartGame(TypePlayer.PlayerVSCPU, TypePlayerController.IAController); // Inicia o jogo Player VS CPU
        }
        else if (modeOption == 2) // Player vs Player
        {
            StartGame(TypePlayer.PlayerVSPlayer, TypePlayerController.Keyboard); // Inicia o jogo Player VS Player
        }
    }

    public void IncrementPoints(TypePlayer player)
    {
        if (player == TypePlayer.PlayerVSPlayer)
        {
            player1Point++;
        }
        else
        {
            player2Point++;
        }

        if ((player1Point == matches) || (player2Point == matches))
        {
            //Tela do Vencedor//
            gameState = TypeGameState.GameOver;
            finalScoreText.text = player1Point.ToString() + " x " + player2Point.ToString();
            panelGameOver.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        Debug.Log("RestartGame Chamando");
        gameState = TypeGameState.Stop;
        Ball.GetComponent<BallBehaviour>().SetStartPosition();
        paddle1.GetComponent<BallBehaviour>().SetStartPosition();
        paddle2.GetComponent<BallBehaviour>().SetStartPosition();
        StartCoroutine(StartBall());
    }
}
