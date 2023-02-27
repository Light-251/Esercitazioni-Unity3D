using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Mov_Tutorial : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    public bool wait = false;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
            wait = true;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            }
            if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            wait = true;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            }
        }
        else if (wait)
        {
            transform.position = transform.position;
            StartCoroutine(waitAtPosition());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
    IEnumerator waitAtPosition()
    {
        yield return new WaitForSeconds(3);
        wait = false;
        //yield return wait;
    }
}
