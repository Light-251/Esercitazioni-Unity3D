using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Background : MonoBehaviour
{
    private GameManager gameManager;
    public Image minusOne;
    public Canvas canvasParent;
    [SerializeField]
    float mouseX;
    [SerializeField]
    float mouseY;
    [SerializeField]
     int valuepoints = 1;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void OnMouseDown()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        Vector3 mouse = new Vector3(mouseX, mouseY, 0f);

        if (gameManager.gameOver == false && PauseMenu.isGamePaused == false)
        {
            gameManager.punteggio -= valuepoints;
            FindObjectOfType<AudioManager>().PlaySound("Missed");
            Instantiate(minusOne, mouse, Quaternion.identity);
        }
    }
}
