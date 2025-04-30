using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBtn : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public GameObject gamePanel;
    public BrickSpawner brickSpawner;
    public BallMultiplierPowerup  ballMultiplierPowerup;

    public BallMovementScript ballMovement;
    // Start is called before the first frame update ///HELL
    public void Homebtn()
    {
        currentPanel.SetActive(false);
        gamePanel.SetActive(false);
        nextPanel.SetActive(true);
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        for (int i = 0; i < brickSpawner.spawnedBricks.Count; i++)
        {
            if (brickSpawner.spawnedBricks[i]){
                  
                brickSpawner.spawnedBricks[i].SetActive(false);
                  
            }
        }
        ballMovement._ballcount = 1;
        ballMultiplierPowerup._useTimes = 2;
        ballMultiplierPowerup.textMesh.text = "2";
        
        brickSpawner.SpawnBrickRow();
    }
}
