// using System;
// using System.IO;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class SaveData : MonoBehaviour
// {
//     public static SaveData instance;
//     public SaveDataItem saveData = new SaveDataItem();
//
//     private string savePath => Application.persistentDataPath + "/saveBrickData.json";
//
//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }
//
//     public void SaveToJson(int highscore, List<GameObject> bricks)
//     {
//         saveData.Highscore = highscore;
//         saveData.BonusBallCount = ScoreScript.Instance.newBallCountforprefab;
//         saveData.CurrentScore = ScoreScript.Instance.GetCurrentScore();
//         saveData.bricks = new List<BrickData>();
//         saveData.powerUps = new List<PowerUpData>();
//
//         foreach (var obj in bricks)
//         {
//             if (!obj.activeSelf) continue;
//
//             if (obj.CompareTag("brick"))
//             {
//                 Brick brickComponent = obj.GetComponent<Brick>();
//                 if (brickComponent != null)
//                 {
//                     BrickData data = new BrickData
//                     {
//                         position = obj.transform.position,
//                         brickValue = brickComponent.brickValue
//                     };
//                     saveData.bricks.Add(data);
//                 }
//             }
//             else if (obj.CompareTag("Multiplier"))
//             {
//                 PowerUpData data = new PowerUpData
//                 {
//                     position = obj.transform.position,
//                     type = obj.name.Replace("(Clone)", "")
//                 };
//                 saveData.powerUps.Add(data);
//             }
//         }
//
//         string json = JsonUtility.ToJson(saveData, true);
//         File.WriteAllText(savePath, json);
//         Debug.Log("Game Saved");
//     }
//
//     public SaveDataItem LoadFromJson()
//     {
//         if (File.Exists(savePath))
//         {
//             string json = File.ReadAllText(savePath);
//             saveData = JsonUtility.FromJson<SaveDataItem>(json);
//             Debug.Log("Game Loaded");
//         }
//         else
//         {
//             Debug.Log("Save file not found.");
//         }
//
//         return saveData;
//     }
//
//     public void DeleteSave()
//     {
//         if (File.Exists(savePath))
//         {
//             File.Delete(savePath);
//             Debug.Log("Save file deleted");
//         }
//     }
// }
//
// [Serializable]
// public class SaveDataItem
// {
//     public int Highscore;
//     public int BallCount;
//     public int BonusBallCount;
//     public int CurrentScore;
//     public List<BrickData> bricks = new List<BrickData>();
//     public List<PowerUpData> powerUps = new List<PowerUpData>(); 
// }
//
// [Serializable]
// public class BrickData
// {
//     public Vector3 position;
//     public int brickValue;
// }
//
// [Serializable]
// public class PowerUpData
// {
//     public Vector3 position;
//     public string type; // E.g., "Multiplier"
// }
//

using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    
    public BallMovementScript ballMovementScript;
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
        saveData.BonusBallCount = ScoreScript.Instance.newBallCountforprefab + ballMovementScript._ballcount - 1;
        
        saveData.CurrentScore = ScoreScript.Instance.GetCurrentScore();
        saveData.bricks = new List<BrickData>();
        saveData.powerUps = new List<PowerUpData>();

        foreach (var obj in bricks)
        {
            if (!obj.activeSelf) continue;

            if (obj.CompareTag("brick"))
            {
                Brick brickComponent = obj.GetComponent<Brick>();
               
                    BrickData data = new BrickData
                    {
                        position = obj.transform.position,
                        brickValue = brickComponent.brickValue
                    };
                    saveData.bricks.Add(data);
                
            }
            else if (obj.CompareTag("Multiplier"))
            {
                PowerUpData data = new PowerUpData
                {
                    position = obj.transform.position,
                    type = obj.name.Replace("(Clone)", "")
                };
                saveData.powerUps.Add(data);
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
    public List<PowerUpData> powerUps = new List<PowerUpData>(); 
}

[Serializable]
public class BrickData
{
    public Vector3 position;
    public int brickValue;
}

[Serializable]
public class PowerUpData
{
    public Vector3 position;
    public string type; 
}

