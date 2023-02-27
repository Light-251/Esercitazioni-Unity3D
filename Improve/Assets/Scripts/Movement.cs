using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Vector3 v3Force;

    [SerializeField]
    KeyCode positive;
    [SerializeField]
    KeyCode negative;
    void FixedUpdate()
    {
        if (Input.GetKey(positive))
        {
            GetComponent<Rigidbody>().velocity += v3Force;
        }
        if (Input.GetKey(negative))
        {
            GetComponent<Rigidbody>().velocity -= v3Force;
        }
    }
}
