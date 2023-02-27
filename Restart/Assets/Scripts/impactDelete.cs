using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactDelete : MonoBehaviour
{
    public float temp = 5f;
    float dest = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dest > temp)
        {
            Destroy(gameObject);
        }
        else
        {
            dest += 1f;
        }

        
    }
}
