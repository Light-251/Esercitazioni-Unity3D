using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migiranoicubi : MonoBehaviour
{
    [SerializeField]
    float vel = 2;
    int max = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (max < 998)
        {
            vel++;
            max++;
        }
        Vector3 direction = new Vector3(1, 1, 1);
        transform.Rotate(direction * vel * Time.deltaTime);
    }
}
