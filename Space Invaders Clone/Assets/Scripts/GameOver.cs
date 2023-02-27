using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool isPlayerDead = false;
    public Text gameOver;
    public Player player;

    public GameObject posSpawner;

    //SPAWN BARRIERE
    public GameObject barrier;
    public Transform placeBarrier;
    public bool isBarrierDestroyed = false;

    

    private void Start()
    {
        //gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        // GAME OVER 
        if (isPlayerDead)
        {
            //Time.timeScale = 0;
            EndGame();
            gameOver.enabled = true;
            Vector3 position = new Vector3();
            position.y = 906.7f;
            position.x = 0;
            position.z = 0;
            gameOver.rectTransform.position = position; 
            Debug.Log(position);
        }
        if (isBarrierDestroyed)
        {
            RespawnBarrier.SpawnBarrier(isBarrierDestroyed, barrier, placeBarrier);
        }
    }
    public class RespawnBarrier : BarrierHealth
    {


        public static void SpawnBarrier(bool destroyed, GameObject barrier, Transform placeBarrier)
        {
            if (destroyed == true)
            {
                Instantiate(barrier, placeBarrier.position, placeBarrier.rotation);
            }
        }
    }
    public float restartDelay = 1f;
    public void EndGame()
    {
        FindObjectOfType<CameraSize>().isGameRunning = false;

        // RICHIAMA LA FUNZIONE RESTART DOPO UN DELAY ESPRESSO IN SECONDI
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("Restart", restartDelay);
        }
        //Restart();
    }
    public void Restart()
    {
        // RICARICA LA SCENA ATTUALMENTE ATTIVA 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<CameraSize>().isGameRunning = true;
        isPlayerDead = false;
    }

}
