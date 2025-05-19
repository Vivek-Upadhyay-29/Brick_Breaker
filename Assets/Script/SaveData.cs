using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public SaveDataItem saveData = new SaveDataItem();

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

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/saveBrickData.json", json);
        Debug.Log("Game Saved");
    }

    public SaveDataItem LoadFromJson()
    {
        string path = Application.persistentDataPath + "/saveBrickData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveDataItem>(json);
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("Save file not found.");
        }

        return saveData;
    }
}

[Serializable]
public class SaveDataItem
{
    public int Highscore;
    public List<BrickData> bricks = new List<BrickData>();
}

[Serializable]
public class BrickData
{
    public Vector3 position;
    public int brickValue;
}
