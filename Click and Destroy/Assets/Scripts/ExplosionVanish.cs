using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionVanish : MonoBehaviour
{
    private GameManager gameManager;
    int sec = 0;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    void Update()
    {
        sec++;
        if (sec >= 30)
        {
            Destroy(gameObject);
        }
        else if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }
}