using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBtn : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public GameObject gamePanel;
    public BrickSpawner brickSpawner;

    // Start is called before the first frame update
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
        brickSpawner.SpawnBrickRow();
    }
}
