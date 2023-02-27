using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAsAChild : MonoBehaviour
{
    public Transform parent;
    void Start()
    {
        parent = FindObjectOfType<Canvas>().GetComponent<Transform>();
        this.transform.SetParent(parent.transform); 
    }
}