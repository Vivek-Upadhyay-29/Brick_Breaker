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

    public void NextPanel()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
    



    public void RestartPanel()
    {
        // currentPanel.SetActive(false);
        // nextPanel.SetActive(true);

        foreach (GameObject brick in brickSpawner.spawnedBricks)
        {
            brick.SetActive(false);
        }

        brickSpawner.spawnedBricks.Clear();
        brickSpawner.SpawnBrickRow();
        currentPanel.SetActive(false);
    }
 
    public void RestartGame()
    {
       currentPanel.SetActive(false);
    }

}
