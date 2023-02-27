using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{ /*            WORK IN PROGRESS   */
    public GameObject limite_superiore = new GameObject();
    public GameObject limite_inferiore = new GameObject();
    
    Vector3 initialPos = new Vector3(-37.99f,-2.05f,-0.1201172f);
    Vector3 finalPos = new Vector3(-37.99f, 0f, -0.1201172f);
    Vector3 currentPos = new Vector3(-37.99f, -2.05f, -0.1201172f); 
    // Start is called before the first frame update
    void Start()
    {
       // this.gameObject.transform.position = initialPos;
       // currentPos = initialPos;

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Debug.Log("currentPos: " + currentPos);
        // MOVIMENTO VERSO IL BASSO
        /*  if (transform.position.y > limite_superiore.transform.position.y)
          {
              StartCoroutine(stayThere());
          }*/
        if (this.gameObject.transform.position.y <= limite_superiore.transform.position.y | this.gameObject.transform.position.y <= 0)
        {
            currentPos.y += 1f;
        }

        Debug.Log("Transform.position.y :" + transform.position.y);
        Debug.Log("Limite Superiore.Transform.Position.y :" + limite_superiore.transform.position.y);
        Debug.Log("Limite Inferiore.Transform.Position.y :" + limite_inferiore.transform.position.y);
        // MOVIMENTO VERSO L'ALTO
        /* if (transform.position.y < limite_inferiore.transform.position.y)
         {
             StartCoroutine(stayThere());
         }*/
        if (this.gameObject.transform.position.y >= limite_inferiore.transform.position.y | this.gameObject.transform.position.y >= 0)
        {
            currentPos.y -= 1f;
        }

        // BLOCCO ASSE X E ASSE Z
        if (currentPos.x != -37.99f)
        {
            currentPos.x = -37.99f;
        }
        if (currentPos.z != -0.1201172f)
        {
            currentPos.z = -0.1201172f;
        }

        // MOVIMENTO
        this.gameObject.transform.position = currentPos;
        Debug.Log("this.gameObject.transform.position : " + this.gameObject.transform.position);
    }

    IEnumerator stayThere()
    {
        yield return new WaitForSeconds(5);
        yield break;
    } /*  */
}