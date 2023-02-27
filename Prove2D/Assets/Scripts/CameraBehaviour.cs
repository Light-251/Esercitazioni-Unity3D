using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform player;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float z_offset = 10f;
    [SerializeField]
    float y_offset = 3f;
    [SerializeField]
    float smooth = 0.3f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Giocatore").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y + y_offset, player.position.z - z_offset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
        }
        
    }
}
