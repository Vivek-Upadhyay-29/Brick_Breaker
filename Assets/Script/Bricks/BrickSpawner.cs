using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Start()
    {
       //LoadBricksFromSave();
        SpawnBrickRow();
    }

    void Update()
    {
        
        int newBallCount = ScoreScript.Instance.newBallCountforprefab;
        if (ballMovementScript._ballcount+ newBallCount <= 8)
        {
            minValue = 8;
        }
        else if (ballMovementScript._ballcount+ newBallCount > 8 && ballMovementScript._ballcount+ newBallCount <= 12)
        {
            minValue = 15;
        }
        else if (ballMovementScript._ballcount+ newBallCount  > 12 && ballMovementScript._ballcount+ newBallCount <= 15)
        {
            minValue = 20;
        }
        else if (ballMovementScript._ballcount + newBallCount > 35)
        {
            minValue = 25;
        }
        else if (ballMovementScript._ballcount + newBallCount > 55)
        {
            
            minValue = 40;
        }
        else if (ballMovementScript._ballcount + newBallCount > 75)
        {
            
            minValue = 50;
        }
    }
    private float GetCurrentEmptyChance()
    {
        float currentChance = initialEmptyChance - (rowsSpawned * emptyChanceDecreaseRate);
        return Mathf.Clamp(currentChance, minEmptyChance, 1f);
    }

    
    public void SpawnBrickRow()
    {
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
                    brickValue = Random.Range(minValue, ballMovementScript._ballcount + 3);
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
                brickValue = Random.Range(1, ballMovementScript._ballcount + 8);
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
    // public void LoadBricksFromSave()
    // {
    //     foreach (var brick in spawnedBricks)
    //     {
    //         if (brick != null)
    //             brick.SetActive(false);
    //     }
    //     spawnedBricks.Clear();
    //
    //     SaveDataItem data = SaveData.instance.LoadFromJson();
    //
    //     foreach (var brickData in data.bricks)
    //     {
    //         GameObject brick = BrickPool.Instance.GetPooledBrick();
    //         if (brick != null)
    //         {
    //             brick.transform.position = brickData.position;
    //             brick.GetComponent<Brick>().SetValue(brickData.brickValue);
    //             brick.SetActive(true);
    //             spawnedBricks.Add(brick);
    //         }
    //     }
    //
    //     rowsSpawned = data.bricks.Count / columns;
    // }
    //

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
