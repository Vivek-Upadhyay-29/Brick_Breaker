using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public SaveDataItem saveData = new SaveDataItem();

    private string savePath => Application.persistentDataPath + "/saveBrickData.json";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveToJson(int highscore, List<GameObject> bricks)
    {
        saveData.Highscore = highscore;
        saveData.BonusBallCount = ScoreScript.Instance.newBallCountforprefab;
        saveData.CurrentScore = ScoreScript.Instance.GetCurrentScore();
        Debug.Log("Saving score: " + saveData.CurrentScore);
        saveData.bricks = new List<BrickData>();

        foreach (var brick in bricks)
        {
            if (brick.activeSelf)
            {
                Brick brickComponent = brick.GetComponent<Brick>();
                if (brickComponent != null)
                {
                    BrickData data = new BrickData
                    {
                        position = brick.transform.position,
                        brickValue = brickComponent.brickValue
                    };
                    saveData.bricks.Add(data);
                }
            }
        }

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved");
    }

    public SaveDataItem LoadFromJson()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            saveData = JsonUtility.FromJson<SaveDataItem>(json);
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("Save file not found.");
        }

        return saveData;
    }

    public void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save file deleted");
        }
    }
}

[Serializable]
public class SaveDataItem
{
    public int Highscore;
    public int BallCount;
    public int BonusBallCount;
    public int CurrentScore;
    public List<BrickData> bricks = new List<BrickData>();
}

[Serializable]
public class BrickData
{
    public Vector3 position;
    public int brickValue;
}
