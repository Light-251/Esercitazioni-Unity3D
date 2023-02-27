using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float damage = 0.5f;
    float durability = 3f;
    public GameObject gun;
    //public GameObject initialPos;
    Vector3 initialPos;
    //new Vector3 destroyPos;


    private void Awake()
    {
        initialPos = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        if (transform.position.x >= (initialPos.x + 50) || transform.position.x <= (initialPos.x-50))
        {
            Destroy(gameObject);
        }
        Debug.Log("initialPos: " + initialPos);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
        //Destroy(gameObject);
        if (durability <= 0)
        {
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
        else
        {
            durability--;
        }
    }
    
}
