using System;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
 
public class SaveData : MonoBehaviour
{
   
    
    public static SaveData instance;
  public SaveDataItem saveData = new SaveDataItem();

  public void SaveToJson(SaveDataItem saveData)
  {
      string brickData = JsonUtility.ToJson(saveData);
      string path = Application.persistentDataPath + "/saveBrickData.json";
      Debug.Log(path);
      System.IO.File.WriteAllText(path, brickData);
      Debug.Log("File saved");
  }

  public void LoadFromJson(SaveDataItem saveData)
  {
      string path = Application.persistentDataPath + "/saveBrickData.json";
      string brickData = System.IO.File.ReadAllText(path);
      Debug.Log(path);
      saveData = JsonUtility.FromJson<SaveDataItem>(brickData);
  }
}

[System.Serializable]

public class SaveDataItem
{
    public int Highscore;
    
}
 
 







