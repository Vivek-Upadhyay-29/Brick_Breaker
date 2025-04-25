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
            
            gameOverpanel.SetActive(true);
            ScoreScript.Instance.Reset();
          for (int i = 0; i < brickSpawner.spawnedBricks.Count; i++)
          {
              if (brickSpawner.spawnedBricks[i]){
                  
                  brickSpawner.spawnedBricks[i].SetActive(false);
                  
              }
          }
          brickSpawner.SpawnBrickRow();
        }
    }
    
}