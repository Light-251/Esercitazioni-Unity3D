using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
          float horizontalMovement = Input.GetAxis("Horizontal");
          float verticalMovement = Input.GetAxis("Vertical");
          Vector3 direction = new Vector3(0,0,0);
          
          if(horizontalMovement !=0)
          {
            direction.z = horizontalMovement;
          }
          if(verticalMovement !=0)
          {
            direction.y = verticalMovement;
          }
          
          transform.Translate(direction * (speed * Time.deltaTime));
          





        /*Vector3 direction = new Vector3(0, 0, 0);
        direction.z = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical") != 0)
        {
            direction.y = Input.GetAxis("Vertical");
        }
        transform.Translate(direction * speed * Time.deltaTime);*/


        /*if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Debug.Log("Destra");

                
            }
            else
            {
                Debug.Log("Sinistra");

            }
        }*/

    }
}
