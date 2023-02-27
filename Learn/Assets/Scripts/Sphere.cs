using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(gameObject.name + "Ha colliso con " + collision.gameObject.name);
    }
}
