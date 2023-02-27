using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Movement myPlayerMovement;
    public static GameObject playerGameObject;

    //[SerializeField]
    public Text punteggioGiocatore1;
    public static int player1Points=0;

    private void Awake()
    {
        player1Points = 0;

        // Codice che definisce un Singleton 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(transform.root.gameObject);
            return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        punteggioGiocatore1.text = ("Giocatore 1: " + player1Points);
        Debug.Log(player1Points);
    }
}
