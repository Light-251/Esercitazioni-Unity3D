using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proiettile : MonoBehaviour
{
    public GameObject targetObj;
    public float speed=1;
    public Transform startPos;
    public float minDistance;
    public float positionX;


    [SerializeField]
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        target = targetObj.transform.position;

        //positionX = transform.position.x;

        if (Vector2.Distance(this.transform.position, targetObj.transform.position) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(this.transform.position, targetObj.transform.position) <= minDistance)
        {
            transform.position = transform.position;
        }
        if(transform.position.x <= targetObj.transform.position.x -1f && transform.position.x >= targetObj.transform.position.x + 1f)
        {
            //positionX += 2f;
            //transform.position =  new Vector3(transform.position.x +2, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, -speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Terrain")
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        //Destroy(gameObject);
    }
}
