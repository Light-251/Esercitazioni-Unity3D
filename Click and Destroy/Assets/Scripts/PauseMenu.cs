using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    private GameManager gameManager;
    public GameObject pauseMenu;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameManager.gameOver == false)
        {
            if (gameManager.gameStarted == true)
            {
                if (isGamePaused)
                {
                    Resume();
                }
                else if (!isGamePaused)
                {
                    Pause();
                }
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
     public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}