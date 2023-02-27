using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giorno_Notte : MonoBehaviour
{
    [SerializeField]
    float speed=2;
    GameObject luce;
    // Start is called before the first frame update
    void Start()
    {
        //float x = luce.transform.rotation.x, y = 153, z = -177;
        // luce.transform.rotation=(860, 153, -177);
        //luce.transform.rotation.y;
        //luce.transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        //speed++;
        Vector3 direction = new Vector3(1, 1, 1);
        transform.Rotate(direction * (speed * Time.deltaTime));   
    }
}
