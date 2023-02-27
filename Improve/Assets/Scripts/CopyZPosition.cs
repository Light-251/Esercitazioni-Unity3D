using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyZPosition : MonoBehaviour
{
    public Transform tranTarget1;
    public Transform tranTarget2;

    public float zMiddlePoint;
    public float xMiddlePoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tranTarget1.position.z == tranTarget2.position.z)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, tranTarget1.position.z);
        }
        else if(tranTarget1.position.z > tranTarget2.position.z)
        {
            zMiddlePoint = tranTarget1.position.z - tranTarget2.position.z;
            transform.position = new Vector3(transform.position.x, transform.position.y, zMiddlePoint);
        }
        else if (tranTarget1.position.x < tranTarget2.position.x)
        {
            xMiddlePoint = tranTarget2.position.x - tranTarget1.position.x;
            transform.position = new Vector3(xMiddlePoint, transform.position.y, transform.position.z);
        }
        if (tranTarget1.position.x == tranTarget2.position.x)
        {
            transform.position = new Vector3(xMiddlePoint, transform.position.y, transform.position.z);
        }
        else if (tranTarget1.position.x > tranTarget2.position.x)
        {
            xMiddlePoint = tranTarget1.position.x - tranTarget2.position.x;
            transform.position = new Vector3(xMiddlePoint, transform.position.y, transform.position.z);
        }
        else if (tranTarget1.position.x < tranTarget2.position.x)
        {
            xMiddlePoint = tranTarget2.position.x - tranTarget1.position.x;
            transform.position = new Vector3(xMiddlePoint, transform.position.y, transform.position.z);
        }
    }
}
