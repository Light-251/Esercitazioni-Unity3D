using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnKey : MonoBehaviour
{
    [SerializeField]
    KeyCode restart;

    void Update()
    {
        if (Input.GetKey(restart))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}