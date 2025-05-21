using System.Collections.Generic;
using UnityEngine;
 
public class gra : MonoBehaviour
{
    [SerializeField] private BrickSpawner brickSpawner;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameplayPanel;
 
    private void Start()
    {
        string savePath = Application.persistentDataPath + "/saveBrickData.json";
 
        if (System.IO.File.Exists(savePath))
        {
            gameOverPanel.SetActive(false);
            gameplayPanel.SetActive(true);
            brickSpawner.LoadBricksFromSave();
        }
        else
        {
            gameOverPanel.SetActive(false);
            gameplayPanel.SetActive(true);
            ScoreScript.Instance.Reset();
            brickSpawner.SpawnBrickRow();
        }
    }
 
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveGame();
        }
    }
 
    private void OnApplicationQuit()
    {
        SaveGame();
    }
 
    private void SaveGame()
    {
        SaveData.instance.SaveToJson(
            ScoreScript.Instance.GetHighScore(),
            brickSpawner.spawnedBricks
        );
        Debug.Log("Game saved on pause/quit.");
    }
}