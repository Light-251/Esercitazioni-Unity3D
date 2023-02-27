using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoyOnGroundCollision : MonoBehaviour
{
    [SerializeField]
    string strCollisionTag1;
    [SerializeField]
    string strCollisionTag2;
    private void OnCollisionEnter(Collision collision)
    {
        if (strCollisionTag1 == collision.collider.tag)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //GameManager.player2Points++;
        }
        else if (strCollisionTag2 == collision.collider.tag)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.player1Points++;
        }
    }
}
