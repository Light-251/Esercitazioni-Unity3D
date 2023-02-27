using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " è entrato");
       
    }
    private void OnTriggerExit(Collider other)
    {
       // Debug.Log(other.gameObject.name + " è uscito");
    }
}
