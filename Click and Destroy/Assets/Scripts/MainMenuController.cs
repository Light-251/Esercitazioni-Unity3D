using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;
    private GameManager gameManager;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject canvasMainMenu;
    public GameObject canvasInGame;
    public GameObject menuBackground;
    public GameObject gameOverPage;
    private PauseMenu pause;
    private void Awake()
    {
        pause = FindObjectOfType<PauseMenu>().GetComponent<PauseMenu>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // AVVIO INIZIALE
        mainMenu.gameObject.SetActive(true);
        optionsMenu.gameObject.SetActive(false);
        canvasInGame.gameObject.SetActive(false);
        canvasMainMenu.SetActive(true);
        menuBackground.SetActive(true);
        gameOverPage.SetActive(false);
    }
    public void QuitGame()
    {
        // FUNZIONE AVVIATA DAL TASTO 'ESCI'
        Application.Quit();
        Debug.Log("Uscita dal gioco...");
    }
    public void LoadMenu()
    {
        // FUNZIONE AVVIATA DAL TASTO 'MENU'
        canvasMainMenu.SetActive(true);
        menuBackground.SetActive(true);
        canvasInGame.SetActive(false);
        gameManager.countSphere = false;
        gameManager.counterSphere = 0;
        gameManager.gameStarted = false;
        gameManager.gameOver = true;
        pause.Resume();
        SceneManager.LoadScene("CaD-MainMenu");
    }
}