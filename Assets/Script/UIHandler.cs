using System.Collections;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private  GameObject currentPanel;
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private  BrickSpawner brickSpawner;
    [SerializeField] private  BallMovementScript ballMovement;
    [SerializeField] private  BallMultiplierPowerup  ballMultiplierPowerup;
    public void NextPanel()
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    public void BackPanel()
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        StartCoroutine(ResumeGame());
   
    }


    public void PauseRealTime()
    {
        Time.timeScale = 0;
        Debug.Log("PauseRealTime");
    }
    public void RealTimer()
    {
        StartCoroutine(ResumeGame());
    }
    IEnumerator ResumeGame()
    {
        yield return new WaitForSecondsRealtime (0.5f);
        Time.timeScale = 1;
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
        yield return null;
    }



    public void RestartGameHome()
    {
        StartCoroutine(RestarrtGame());
    }

    IEnumerator RestarrtGame()
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
        ScoreScript.Instance.newBallCountforprefab = 0;
        ballMovement._ballcount = 1;
        brickSpawner.SpawnBrickRow();
        yield return new WaitForSecondsRealtime (0.5f);
        Time.timeScale = 1;
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
        yield return null;
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
            ScoreScript.Instance.newBallCountforprefab = 0;
            ballMovement._ballcount = 1;
            brickSpawner.SpawnBrickRow();
    }
 
    public void RestartGame()
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        StartCoroutine(ResumeGamee());

    }
    IEnumerator ResumeGamee()
    {
        yield return new WaitForSecondsRealtime (0.5f);
        currentPanel.SetActive(false);
        yield return null;
    }

    public void QuitGame()
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);

        // SaveData.instance.SaveToJson(
        //     ScoreScript.Instance.GetHighScore(),
        //     brickSpawner.spawnedBricks
        // );

        Application.Quit();
    }

}
