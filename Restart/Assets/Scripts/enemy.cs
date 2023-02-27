using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float healt = 1.5f;
    //Bullet bulletDamage;
    public GameObject deathEffect;
    public bool facingRight = false;
    void Awake()
    {
       // bulletDamage = GetComponent<Bullet>();
       // bulletDamage.damage = 0.5f;
        healt = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //float damage = bulletDamage.damage;
        if (collision.tag == "Bullet")
        {
            healt -= 0.5f;
        }
        if (healt <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        if (collision.tag == "Wall")
        {
            facingRight = !facingRight;
        }
    }
}
