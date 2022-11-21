using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string target_name;
    public string scene;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == target_name)
        {
            SceneManager.LoadScene(scene);
        }
    }

}
