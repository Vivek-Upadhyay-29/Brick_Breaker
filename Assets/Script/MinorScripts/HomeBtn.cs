using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBtn : MonoBehaviour
{
    [SerializeField] private  GameObject currentPanel;
    [SerializeField] private  GameObject nextPanel;
    [SerializeField] private  GameObject gamePanel;
    [SerializeField] private  BrickSpawner brickSpawner;
    [SerializeField] private  BallMultiplierPowerup  ballMultiplierPowerup;

    public BallMovementScript ballMovement;
    // Start is called before the first frame update ///HELL
    public void Homebtn()
    {
       StartCoroutine(ResumeGame());
    }
    IEnumerator ResumeGame()
    {
        yield return new WaitForSecondsRealtime (0.5f);
        Time.timeScale = 1;
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
        yield return null;
    }
}
