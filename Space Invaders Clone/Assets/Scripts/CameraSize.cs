using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{

    public Camera camera;
   public bool isGameRunning = true;
    bool ingr = true;
    public float speed = 0.1f;
    public float minBound = 5f, maxBound = 10f;
    // Start is called before the first frame update
    void Start()
    {
        camera.orthographic = true;
        //camera.orthographicSize = 6f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            if (ingr)
            {
                if (camera.orthographicSize <= minBound || camera.orthographicSize <= maxBound)
                {
                    camera.orthographicSize += speed;
                }
                else if (camera.orthographicSize >= maxBound)
                {
                    ingr = false;
                }
            }
            else if (!ingr)
            {
                if (camera.orthographicSize >= maxBound || camera.orthographicSize > minBound)
                {
                    camera.orthographicSize -= speed;
                }
                else if (camera.orthographicSize <= minBound)
                {
                    ingr = true;
                }
            }
        }
    }
}
