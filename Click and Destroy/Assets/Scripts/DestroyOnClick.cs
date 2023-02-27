using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public int valore;
    public GameObject explosion;
    public GameObject plusOne;
    public GameObject plusTwo;
    public GameManager gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        // ASSEGNAZIONE VALORE OGGETTO
        gameManager.counterSphere++;
        gameManager.countSphere = true;
        if (gameObject.CompareTag("1 Point"))
        {
            valore = 1;
            gameManager.maxPoints += valore;
        }
        else if (gameObject.CompareTag("2 Points"))
        {
            valore = 2;
            gameManager.maxPoints += valore;
        }
    }
    // DISTRUZIONE SFERA AL CLICK
    void OnMouseDown()
    {
        if (gameManager.gameOver == false && PauseMenu.isGamePaused == false)
        {
            if (gameObject.CompareTag("1 Point"))
            {
                Instantiate(plusOne, transform.position, Quaternion.identity);
            }
            else if (gameObject.CompareTag("2 Points"))
            {
                Instantiate(plusTwo, transform.position, Quaternion.identity);
            }
            FindObjectOfType<AudioManager>().PlaySound("BalloonPOP");
            gameManager.punteggio += valore;
            gameManager.counterSphere--;
            Destroy(gameObject);
        }
    }
}