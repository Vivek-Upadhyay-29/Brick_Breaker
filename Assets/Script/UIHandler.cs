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
       currentPanel.SetActive(false);
    }

    public void QuitGame()
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BUTTON);
        Application.Quit();
    }
}
