using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // VARIABILI PUNTEGGIO
    public int punteggio;
    public GameObject imgScore;
    public TMP_Text txtScore;
    public int maxPoints;
    // VARIABILI TEMPO
    public GameObject imgTimer;
    public TMP_Text txtTimer;
    float currentTime = 1;
    public float startingTime = 20;
    // VARIABILI GAME OVER
    public TMP_Text txtGameOver;
    public bool gameOver = false;
    bool suonoGameOver = true; 
    public bool gameStarted = false;
    // VARIABILI CONTEGGIO SFERE
    public int counterSphere = 0;
    public bool countSphere = false;
    public static GameManager gameManager;
    MainMenuController menuController;

    void Awake()
    {
        suonoGameOver = true;
        menuController = FindObjectOfType<MainMenuController>().GetComponent<MainMenuController>();
        // SINGLETON
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gameOver = false;
        gameManager = this;
        currentTime = startingTime;
        punteggio = 0;
        txtGameOver.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {

        // AGGIORNAMENTO TIMER
        if (gameOver == false && gameStarted)
        {
            currentTime -= 1 * Time.fixedDeltaTime;
            txtTimer.text = string.Format("Tempo: {0:#0.0}s", currentTime);
        }
    }
    void Update()
    {
        // AGGIORNAMENTO TESTO PUNTI
        if (punteggio < 0)
            punteggio = 0;
        txtScore.text = "Punti: " + punteggio.ToString();
        // CONTROLLO CONDIZIONI DI GAME OVER
        if (currentTime < 0 || (counterSphere == 0 && countSphere))
        {
            gameOver = true;
        }
        // SCHERMATA GAME OVER
        if (gameOver == true)
        {
            if (suonoGameOver)
            {
                SuonoGameOver();
            }
            menuController.gameOverPage.SetActive(true);
            // ATTIVA SCHERMATA SE FNISCE IL TEMPO
            if (punteggio != maxPoints && currentTime <= 0)
            {
                txtGameOver.gameObject.SetActive(true);
                txtGameOver.text = "GAME OVER\nIl tuo punteggio è: " + punteggio.ToString() + "/" + maxPoints.ToString() + "\nTempo esaurito. ";

            }
            // ATTIVA SCHERMATA SE VIENE RAGGIUNTO IL PUNTEGGIO MASSIMO
            else if (punteggio == maxPoints && counterSphere == 0)
            {
                txtGameOver.gameObject.SetActive(true);
                txtGameOver.text = "GAME OVER\nPunteggio Massimo\nTempo rimasto: " + currentTime.ToString() + "s";
            }
            // ATTIVA SCHERMATA SE I PALLONCINI SONO FINITI
            else if (punteggio != maxPoints && counterSphere == 0)
            {
                txtGameOver.gameObject.SetActive(true);
                txtGameOver.text = "GAME OVER\nIl tuo punteggio è: " + punteggio.ToString() + "/" + maxPoints.ToString() + "\nTempo rimasto: " + currentTime.ToString() + "s";
            }
            imgScore.gameObject.SetActive(false);
            imgTimer.gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        // FUNZIONE AVVIATA DAL TASTO 'GIOCA'
        menuController.canvasMainMenu.SetActive(false);
        menuController.menuBackground.SetActive(false);
        menuController.canvasInGame.SetActive(true);
        gameStarted = true;
        gameOver = false;
        currentTime = startingTime;
        punteggio = 0;
        txtGameOver.gameObject.SetActive(false);
        countSphere = false;
        maxPoints = 0; 
        suonoGameOver = true;
        imgScore.gameObject.SetActive(true);
        imgTimer.gameObject.SetActive(true);
        menuController.gameOverPage.SetActive(false);
        //minusOne.gameObject.SetActive(true);
        PauseMenu.isGamePaused = false;
        // CARICARE SCENA GIOCO ( CaD-GameScene )
        SceneManager.LoadScene("CaD-GameScene");

    }
    public void NewGameReset()
    {
        // FUNZIONE AVVIATA DAL TASTO 'RIPROVA'
        currentTime = startingTime;
        punteggio = 0;
        txtGameOver.gameObject.SetActive(false);
        gameOver = false;
        gameStarted = false;
        countSphere = false;
        StartGame();
        maxPoints = 0;
        imgScore.gameObject.SetActive(true);
        imgTimer.gameObject.SetActive(true);
        //minusOne.gameObject.SetActive(true);
        PauseMenu.isGamePaused = false;
    }
    public void SuonoGameOver()
    {
        FindObjectOfType<AudioManager>().PlaySound("GameOver");
        suonoGameOver = false;
    }
}