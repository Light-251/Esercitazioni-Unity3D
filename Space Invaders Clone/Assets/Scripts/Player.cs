using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    public float moveSpeed;
    public float acc;
    public float healt;
    public float maxBound=-5f, minBound=5f;

    private Transform player;
    //Sparo
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public bool rightShot = false;
    public float nextFire;

    //SPRINT
    public float sprintCool;
    public float nextSprint;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        healt = 5;
    }

    // Update is called once per frame
   /*private void FxiedUpdate()
    {
        //METOO DUE
        

        //METODO UNO
        /*if (Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0)
        {
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
            float verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
            Vector3 directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);
            gameObject.transform.Translate(directionOfMovement);
        }
    }*/
    private void Update()
    {
        //        CODICE SPARO PROIETTILE
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            float x = shotSpawn.position.x;
            float y = shotSpawn.position.y;
            nextFire = Time.time + fireRate;
            if (rightShot)
            {
                Vector3 position = new Vector3(/*(x + 0.37), y - 2.853, 0*/);
                position.x = x + 0.37f;
                position.y = y + 0.65f;
                Instantiate(shot, position, shotSpawn.rotation);
                rightShot = false;
            }
            else
            {
                Vector3 position = new Vector3(/*(x + 0.37), y - 2.853, 0*/);
                position.x = x - 0.37f;
                position.y = y + 0.65f;
                Instantiate(shot, position, shotSpawn.rotation);
                rightShot = true;
            }

        }
    }
    private void FixedUpdate()
{
        if (FindObjectOfType<GameOver>().isPlayerDead == false)
        {
            //     CODICE MOVIMENTO
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Fire1"))
                h /= 2;

            if (player.position.x < minBound && h < 0)
                h = 0;
            else if (player.position.x > maxBound && h > 0)
                h = 0;
            //SPRINT
            if ((Input.GetKeyDown("space") || Input.GetButtonDown("Fire2"))/*&& !Input.GetButton("Fire1")*/ && Time.time > nextSprint)
            {

                nextSprint = Time.time + sprintCool;
                player.position += Vector3.right * h /* moveSpeed */ * acc;
                player.position += Vector3.up * v /* moveSpeed */ * acc;

            }
            else
            {
                player.position += Vector3.right * h * moveSpeed;
                player.position += Vector3.up * v * moveSpeed;
            }
        }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            healt--;
            Destroy(collision.gameObject);
            if (healt == 0)
            {
                //Time.timeScale = 0;
                FindObjectOfType<GameOver>().isPlayerDead = true;
            }
        }
        
    }
}