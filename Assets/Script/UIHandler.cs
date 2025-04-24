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
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
    



    public void RestartPanel()
    {
            // // currentPanel.SetActive(false);
            // // nextPanel.SetActive(true);
            //
            // foreach (GameObject brick in brickSpawner.spawnedBricks)
            // {
            //     brick.SetActive(false);
            // }
            //
            // brickSpawner.spawnedBricks.Clear();
            // brickSpawner.SpawnBrickRow();
            // currentPanel.SetActive(false);
            //
            AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
            for (int i = 0; i < brickSpawner.spawnedBricks.Count; i++)
            {
                if (brickSpawner.spawnedBricks[i]){
                  
                    brickSpawner.spawnedBricks[i].SetActive(false);
                  
                }
            }
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
