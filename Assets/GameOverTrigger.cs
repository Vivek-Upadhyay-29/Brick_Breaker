using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverTrigger : MonoBehaviour
{
    
    public GameObject gameOverpanel;
    public BrickSpawner brickSpawner;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Multiplier" || collision.gameObject.tag =="clone" || collision.gameObject.tag == "brick")
        {
      
            //  Scene currentScene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(currentScene.name);
             gameOverpanel.SetActive(true);
            Debug.Log("Game Over");
            // for (int i = 0; i < brickSpawner.spawnedBricks.Count; i++)
            // {
            //     GameObject brick = BrickPool.Instance.GetPooledBrick();
            //     brick.SetActive(false);
            //
            // }
            
            brickSpawner.SpawnBrickRow();
            // StartCoroutine(EndGame());

        }
    }

    // IEnumerator EndGame()
    // {
    //      Scene currentScene = SceneManager.GetActiveScene();
    //     SceneManager.LoadScene(currentScene.name);
    //     yield return new WaitForSeconds(0.2f);
    //     gameOverpanel.SetActive(true);
    //
    // }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Multiplier" || other.gameObject.tag == "clone" )
        {
            gameOverpanel.SetActive(true);
        }
    }
}
