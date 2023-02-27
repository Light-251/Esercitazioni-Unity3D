using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
        
    public float speed;
    public float maxBound = 10f, minBound = -10f;

    public int health=7;
    
    bool rightMov = true;
    private Transform enemy;

    // VARIABILI SPARO
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.9f;
        enemy = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {       

        if (rightMov)
        {
            enemy.position += Vector3.right * speed;
        }
        else if (!rightMov)
        {
            enemy.position += Vector3.left * speed;
        }

        if (enemy.position.x < minBound)
        {
            enemy.position += Vector3.right * speed;
            rightMov = true;
        }
        else if (enemy.position.x > maxBound)
        {
            enemy.position += Vector3.left * speed;
            rightMov = false;
        }
        /*else if (enemy.position.x > minBound && enemy.position.x < maxBound)
            enemy.position += Vector3.right * speed;*/
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<Score>().score += FindObjectOfType<Score>().increaseScore;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


        
        if(Random.value > fireRate && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, enemy.position, enemy.rotation);
        }
       
    }
}
