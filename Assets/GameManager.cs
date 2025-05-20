using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BrickSpawner brickSpawner;

    void OnApplicationQuit()
    {
        if (SaveData.instance != null)
        {
            SaveData.instance.SaveToJson(
                ScoreScript.Instance.GetHighScore(),
                brickSpawner.spawnedBricks
            );
        }
    }
}
