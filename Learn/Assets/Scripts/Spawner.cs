using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
     GameObject cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log("Spawnato " + gameObject.name, gameObject);
       // Instantiate(cubePrefab);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonUp(0))
       // if(Input.GetButtonDown ("Fire1"))
     //   {
            Instantiate(cubePrefab, new Vector3(Random.Range(-30,30), 0, Random.Range(-30,30)), cubePrefab.transform.rotation);
      //  }

        if (Input.GetButton("Fire2"))
        {
            Instantiate(cubePrefab, new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30)), cubePrefab.transform.rotation);
        }

    }
}
