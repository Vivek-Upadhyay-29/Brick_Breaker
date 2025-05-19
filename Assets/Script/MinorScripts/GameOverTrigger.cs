using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private  GameObject gameOverpanel;
    [SerializeField] private BrickSpawner brickSpawner;
    [SerializeField] private  BallMovementScript ballMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Multiplier") || collision.CompareTag("clone") || collision.CompareTag("brick"))
        {
            
            Time.timeScale = 0;
            gameOverpanel.SetActive(true);
            ScoreScript.Instance.Reset();
           for (int i = 0; i < brickSpawner.spawnedBricks.Count; i++)
           {
               if (brickSpawner.spawnedBricks[i]){
                  
                   brickSpawner.spawnedBricks[i].SetActive(false);
                   brickSpawner.spawnedBricks[i].transform.SetParent(null); 
               }
           }

           //resetting all things
           // SaveData.instance.SaveToJson(
           //     ScoreScript.Instance.GetHighScore(),
           //     brickSpawner.spawnedBricks);

           ballMovement._ballcount = 1;
           ScoreScript.Instance.newBallCountforprefab = 0;
           brickSpawner.spawnedBricks.Clear(); 
           brickSpawner.ResetRowCount();
           brickSpawner.SpawnBrickRow();
        }
        
    }
 


}