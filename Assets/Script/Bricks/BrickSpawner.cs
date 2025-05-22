using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> brickPrefabs = new List<GameObject>();
    [SerializeField] private float spacing = 0.8f;
    public List<GameObject> spawnedBricks = new List<GameObject>();
    [SerializeField] private BallMovementScript ballMovementScript;
    [SerializeField] private int columns = 5;
    [Range(0f, 1f)] public float powerUpSpawnChance = 0.15f;
    [Range(0f, 1f)] public float initialEmptyChance = 0.7f;
    [Range(0f, 1f)] public float minEmptyChance = 0.2f;
    [SerializeField] private float emptyChanceDecreaseRate = 0.05f;
    [Range(0f, 1f)][SerializeField] private float gettingPowerupChance = 0.6f;
    [SerializeField] private float powerUpVerticalOffset = -0.1f;
     public int minValue = 1;
    [SerializeField] private int rowsSpawned = 0;
    private bool isShifting = false;





    public GameObject brickPrefab;

    // public void LoadBricksFromSave()
    // {
    //     SaveDataItem data = SaveData.instance.LoadFromJson();
    //     ScoreScript.Instance.SaveHighScore(data.Highscore);
    //     ScoreScript.Instance.SetScore(data.CurrentScore);
    //     ScoreScript.Instance.newBallCountforprefab = data.BonusBallCount;
    //
    //     ScoreScript.Instance.SetScore(data.CurrentScore);
    //
    //     foreach (var brick in spawnedBricks)
    //     {
    //         if (brick != null)
    //             Destroy(brick);
    //     }
    //
    //     spawnedBricks.Clear();
    //
    //     foreach (var brickData in data.bricks)
    //     {
    //         GameObject brick = Instantiate(brickPrefab, brickData.position, Quaternion.identity);
    //         Brick brickComponent = brick.GetComponent<Brick>();
    //         if (brickComponent != null)
    //         {
    //             brickComponent.SetValue(brickData.brickValue);
    //         }
    //         spawnedBricks.Add(brick);
    //     }
    // }

    public void LoadBricksFromSave()
    {
        SaveDataItem data = SaveData.instance.LoadFromJson();

        ScoreScript.Instance.SaveHighScore(data.Highscore);
        ScoreScript.Instance.SetScore(data.CurrentScore);
        ScoreScript.Instance.newBallCountforprefab   = data.BonusBallCount;

        foreach (var obj in spawnedBricks)
        {
            if (obj != null)
                Destroy(obj);
        }
        spawnedBricks.Clear();

        foreach (var brickData in data.bricks)
        {
            GameObject brick = Instantiate(brickPrefab, brickData.position, Quaternion.identity);
           
            Brick brickComponent = brick.GetComponent<Brick>();
            if (brickComponent != null)
            {
                brickComponent.SetValue(brickData.brickValue);
            }
            spawnedBricks.Add(brick);
        }

        foreach (var powerUpData in data.powerUps)
        {
            GameObject powerUp = BrickPool.Instance.GetPooledPowerUp(); 
            powerUp.transform.position = powerUpData.position;
            powerUp.SetActive(true);

            spawnedBricks.Add(powerUp);
        }
    }



    void Start()
    {


     
            bool saveExists = System.IO.File.Exists(Application.persistentDataPath + "/saveBrickData.json");

            if (saveExists && SaveData.instance != null)
            {
                LoadBricksFromSave(); 
            }
            else
            {
                ScoreScript.Instance.Reset(); 
                SpawnBrickRow();
            }
        

    }

    //void Update()
    //{
    //    int totalBalls = ballMovementScript._ballcount + ScoreScript.Instance.newBallCountforprefab;

    //    int newMinValue = minValue; 

    //    if (totalBalls <= 8)
    //        newMinValue = 3;
    //    else if (totalBalls <= 12)
    //        newMinValue = 15;
    //    else if (totalBalls <= 15)
    //        newMinValue = 20;
    //    else if (totalBalls <= 35)
    //        newMinValue = 25;
    //    else if (totalBalls <= 55)
    //        newMinValue = 40;
    //    else if (totalBalls <= 75)
    //        newMinValue = 50;
    //    else
    //        newMinValue = 60;

    //    if (newMinValue != minValue)
    //    {
    //        Debug.Log($"minValue changed from {minValue} to {newMinValue}");
    //        minValue = newMinValue;

    //    }
    //}
    void Update()
    {
        int newMinValue = CalculateMinValue();

        if (newMinValue != minValue)
        {
            Debug.Log($"minValue changed from {minValue} to {newMinValue}");
            minValue = newMinValue;
        }
    }
    private int CalculateMinValue()
    {
        int totalBalls = ballMovementScript._ballcount + ScoreScript.Instance.newBallCountforprefab;
        float difficultyFactor = Mathf.Log10(totalBalls + 1); 
        int minValue = Mathf.FloorToInt(2 + difficultyFactor * 5);
        return minValue;
    }


    private float GetCurrentEmptyChance()
    {
        float currentChance = initialEmptyChance - (rowsSpawned * emptyChanceDecreaseRate);
        return Mathf.Clamp(currentChance, minEmptyChance, 1f);
    }

    
    public void SpawnBrickRow()
    {
        foreach (GameObject brick in spawnedBricks)
        {
            if (brick != null && brick.activeSelf)
                brick.SetActive(false);
        }

        

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float emptyRoll = Random.value;
                float currentEmptyChance = GetCurrentEmptyChance();
                int brickValue = 0;
                
                //this for deciding bricks
                if (emptyRoll > currentEmptyChance)
                {
                    int maxValue = ballMovementScript._ballcount + ScoreScript.Instance.newBallCountforprefab + 5;
                    brickValue = Random.Range(minValue, Mathf.Max(minValue + 1, maxValue));

                   // brickValue = Random.Range(minValue, ballMovementScript._ballcount + 3);
                }

                Vector3 spawnPos = transform.position + new Vector3(j * spacing, i * -spacing, 0);

                if (brickValue == 0)
                { 
                    //yah ball multiplier
                    if (!(Random.value < (1f - gettingPowerupChance)))
                    {
                        GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
                        powerUp.transform.position = spawnPos + new Vector3(0, powerUpVerticalOffset, 0);
                        powerUp.SetActive(true);
                        spawnedBricks.Add(powerUp);
                    }
                }
                else
                {
                    //for bricks
                    GameObject brickObj = BrickPool.Instance.GetPooledBrick();
                    brickObj.transform.position = spawnPos;
                    spawnedBricks.Add(brickObj);
                    Brick brickComponent = brickObj.GetComponent<Brick>();
                    brickComponent.SetValue(brickValue);
                    brickObj.SetActive(true);
                }
            }
        }
        rowsSpawned += 2;
    }

    public void MoveDownAndAddNewRow()
    {
        if (!isShifting)
        {
            StartCoroutine(ShiftAndAdd());
        }
    }

    IEnumerator ShiftAndAdd()
    {
        isShifting = true;

        foreach (GameObject brick in spawnedBricks)
        {
            if (brick != null && brick.activeInHierarchy)
            {
                StartCoroutine(TileDown(brick.transform));
            }
        }

        yield return new WaitForSeconds(0.35f);
        NewLineSpawner();
        isShifting = false;
    }

    private void NewLineSpawner()
    {
        float currentEmptyChance = GetCurrentEmptyChance();

        for (int j = 0; j < columns; j++)
        {
            float emptyRoll = Random.value;
            int brickValue = 0;

            if (emptyRoll > currentEmptyChance)
            {
                int maxValue = ballMovementScript._ballcount + ScoreScript.Instance.newBallCountforprefab + 5;
                brickValue = Random.Range(minValue, Mathf.Max(minValue + 1, maxValue));

             //   brickValue = Random.Range(minValue, ballMovementScript._ballcount + 8);
            }

            Vector3 spawnPos = transform.position + new Vector3(j * spacing, 0, 0);

            if (brickValue == 0)
            {
                if (!(Random.value < (1f - gettingPowerupChance)))
                {
                    GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
                    powerUp.transform.position = spawnPos + new Vector3(0, powerUpVerticalOffset, 0);
                    powerUp.SetActive(true);
                    spawnedBricks.Add(powerUp);
                }
            }
            else
            {
                GameObject brickObj = BrickPool.Instance.GetPooledBrick();
                brickObj.transform.position = spawnPos;
                spawnedBricks.Add(brickObj);
                Brick brickComponent = brickObj.GetComponent<Brick>();
                brickComponent.SetValue(brickValue);
                brickObj.SetActive(true);
            }
        }
        rowsSpawned++;
    }

    public void ResetRowCount()
    {
        rowsSpawned = 0;
    }
   

    IEnumerator TileDown(Transform brick)
    {
        Vector3 start = brick.position;
        Vector3 end = start + new Vector3(0, -spacing, 0);
        float elapsedTime = 0f;
        float duration = 0.3f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            brick.position = Vector3.Lerp(start, end, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        brick.position = end;
    }

}
