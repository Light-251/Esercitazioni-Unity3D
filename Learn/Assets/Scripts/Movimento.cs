using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public int score = 0;

    [SerializeField]
    float speed = 10;
    [SerializeField]
    GameObject rimpiazzo;
    [SerializeField]
    GameObject cubo;

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Debug.Log(cubo + " è stato distrutto");
        Instantiate(rimpiazzo, new Vector3(-35,30,Random.Range(-35,35)), rimpiazzo.transform.rotation);
        //rimpiazzo.transform.rotation
        score++;
        Debug.Log("Il punteggio è: " + score);
    }
    void Update()
    {
        float horizontalMovement;
        float verticalMovement;

        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(0, 0, 0);

        if(horizontalMovement != 0)
        {
            direction.z = horizontalMovement;
        }
        if(verticalMovement != 0)
        {
            direction.x = - verticalMovement;
        }

        transform.Translate(direction * (speed * Time.deltaTime));
    }
}
