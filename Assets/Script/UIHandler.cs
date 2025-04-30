using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIHandler : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public BrickSpawner brickSpawner;
    public BallMovementScript ballMovement;
    public BallMultiplierPowerup  ballMultiplierPowerup;
    public void NextPanel()
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
    
    public void Homebtn()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
        ScoreScript.Instance.Reset();
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        for (int i = 0; i < brickSpawner.spawnedBricks.Count; i++)
        {
            if (brickSpawner.spawnedBricks[i]){
                  
                brickSpawner.spawnedBricks[i].SetActive(false);
                  
            }
        }
        ballMovement._ballcount = 2;
        brickSpawner.SpawnBrickRow();
    }
    
    public void RestartPanel()
    {
        ScoreScript.Instance.Reset();
            AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
            for (int i = 0; i < brickSpawner.spawnedBricks.Count; i++)
            {
                if (brickSpawner.spawnedBricks[i]){
                  
                    brickSpawner.spawnedBricks[i].SetActive(false);
                  
                }
            }

            ballMultiplierPowerup._useTimes = 2;
            ballMultiplierPowerup.textMesh.text = "2";
            
            ballMovement._ballcount = 2;
            brickSpawner.SpawnBrickRow();
    }
 
    public void RestartGame()
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
       currentPanel.SetActive(false);
    }

    public void QuitGame()
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        Application.Quit();
    }
}
