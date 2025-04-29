using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverpanel;
    public BrickSpawner brickSpawner;
    public BallMovementScript ballMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Multiplier") || collision.CompareTag("clone") || collision.CompareTag("brick"))
        {
            
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
          ballMovement._ballcount = 2;
          brickSpawner.spawnedBricks.Clear(); 
          brickSpawner.ResetRowCount();
          brickSpawner.SpawnBrickRow();
        }
        
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Multiplier") || collision.CompareTag("clone") || collision.CompareTag("brick"))
    //     {
    //         gameOverpanel.SetActive(true);
    //         ScoreScript.Instance.Reset();
    //
    //         // sab bricks aur powerup ke liye
    //         for (int i = 0; i < brickSpawner.spawnedBricks.Count; i++)
    //         {
    //             if (brickSpawner.spawnedBricks[i])
    //             {
    //                 brickSpawner.spawnedBricks[i].SetActive(false);
    //                 brickSpawner.spawnedBricks[i].transform.SetParent(null); 
    //                 // for parent in  powerups
    //             }
    //         }
    //
    //         brickSpawner.spawnedBricks.Clear();
    //         brickSpawner.ResetRowCount();
    //
    //         // Spawn fresh bricks
    //         brickSpawner.SpawnBrickRow();
    //     }
    // }


}