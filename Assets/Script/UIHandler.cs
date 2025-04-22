using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIHandler : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;


    public void NextPanel()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
    



    public void RestartPanel()
    {
        // currentPanel.SetActive(false);
        // nextPanel.SetActive(true);
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Debug.Log("Restart Game");
    }

    public void QuitPanel()
    {

    }
}
