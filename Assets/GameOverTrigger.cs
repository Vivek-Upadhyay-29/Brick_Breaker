// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
//
//
// public class GameOverTrigger : MonoBehaviour
// {
//     
//     public GameObject gameOverpanel;
//     public BrickSpawner brickSpawner;
//
//     // Start is called before the first frame update
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.tag == "Multiplier" || collision.gameObject.tag =="clone" || collision.gameObject.tag == "brick")
//         {
//             //foreach (GameObject brick in brickSpawner.spawnedBricks)
//             //{
//             //    brick.SetActive(false);
//             //}
//
//
//             //brickSpawner.spawnedBricks.Clear();
//             //brickSpawner.SpawnBrickRow();
//             //gameOverpanel.SetActive(true);
//            
//             StartCoroutine(WaitAndLoad());
//             gameOverpanel.SetActive(true);
//         }
//     }
//
//
//      IEnumerator WaitAndLoad()
//     {
//         Scene currentScene = SceneManager.GetActiveScene();
//         SceneManager.LoadScene(currentScene.name);
//         yield return new WaitForSeconds(2f);
//         yield return null;
//
//     }
//
//     private void OnTriggerStay2D(Collider2D other)
//     {
//         if (other.gameObject.tag == "Multiplier" || other.gameObject.tag == "clone" )
//         {
//           //  gameOverpanel.SetActive(true);
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverpanel;
    public BrickSpawner brickSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Multiplier") || collision.CompareTag("clone") || collision.CompareTag("brick"))
        {
   
            StartCoroutine(WaitAndLoad());
          //  gameOverpanel.SetActive(true);
           
        }
    }
    
    IEnumerator WaitAndLoad()
    {
       
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name); 
        yield return new WaitForSecondsRealtime(2f); 
        yield return null;
       
    }
}