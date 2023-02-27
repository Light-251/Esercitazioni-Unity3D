using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        if ((bullet.position.y - FindObjectOfType<Player>().shotSpawn.position.y) >= 10)
            Destroy(gameObject);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        else if (other.tag == "Base")
            Destroy(gameObject);
    }*/
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            Destroy(gameObject);
    }*/

}
