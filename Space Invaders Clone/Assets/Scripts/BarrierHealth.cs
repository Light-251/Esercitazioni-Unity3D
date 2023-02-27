using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierHealth : MonoBehaviour
{
    public bool isBarrierDestroyed = false;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag=="Bullet")
        {
            health--;
        }
        if (health<=0)
        {
            Destroy(gameObject);
            isBarrierDestroyed = true;
            //FindObjectOfType<BarrierSpawn>().
        }
    }
}