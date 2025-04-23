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
            //foreach (GameObject brick in brickSpawner.spawnedBricks)
            //{
            //    brick.SetActive(false);
            //}


            //brickSpawner.spawnedBricks.Clear();
            //brickSpawner.SpawnBrickRow();
            //gameOverpanel.SetActive(true);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            StartCoroutine(WaitAndLoad());
            gameOverpanel.SetActive(true);

        }
    }


    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(1f);
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Multiplier" || other.gameObject.tag == "clone" )
        {
            gameOverpanel.SetActive(true);
        }
    }
}
