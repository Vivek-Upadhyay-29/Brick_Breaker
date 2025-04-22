using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverTrigger : MonoBehaviour
{
    
    public GameObject gameOverpanel;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Multiplier" || collision.gameObject.tag =="clone")
        {
            
            gameOverpanel.SetActive(true);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Multiplier" || other.gameObject.tag == "clone")
        {
            gameOverpanel.SetActive(true);
        }
    }
}
