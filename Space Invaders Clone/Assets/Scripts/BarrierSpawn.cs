using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawn : MonoBehaviour
{

    public GameObject rightBarrier;
    public GameObject leftBarrier;
    bool isRight = true;
    bool isLeft = true;

    public Transform father;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float delaySpawn = 5f;
    public void SpawnBarrier()
    {
        if (FindObjectOfType<BarrierHealth>().health == 0)
        {
            //Invoke("SpawnRight", delaySpawn);
            SpawnRight();
        }
        if (FindObjectOfType<BarrierHealth>().health == 0)
        {
            Invoke("SpawnLeft", delaySpawn);
        }
    }
    public void SpawnRight()
    {
        Vector3 positionRight = new Vector3();

        positionRight.x = father.position.x + 4;
        Instantiate(rightBarrier, positionRight, father.rotation);
    }
    public void SpawnLeft()
    {
        Vector3 positionLeft = new Vector3();

        positionLeft.x = father.position.x - 4;
        Instantiate(leftBarrier, positionLeft, father.rotation);
    }
}
