using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickSpawner : MonoBehaviour
{
    public List<GameObject> brickPrefabs = new List<GameObject>();
    public float spacing = 0.8f;
    public List<GameObject> spawnedBricks = new List<GameObject>();
    public BallMovementScript ballMovementScript;
    public int columns = 5;
    [Range(0f, 1f)] public float powerUpSpawnChance = 0.15f;
    [Range(0f, 1f)] public float initialEmptyChance = 0.7f;
    [Range(0f, 1f)] public float minEmptyChance = 0.2f;
    public float emptyChanceDecreaseRate = 0.05f;
    [Range(0f, 1f)] public float gettingPowerupChance = 0.6f;
    public float powerUpVerticalOffset = -0.1f;

    private int rowsSpawned = 0;

    void Start()
    {
        SpawnBrickRow();
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
                    brickValue = Random.Range(1, ballMovementScript._ballcount + 8);
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
        StartCoroutine(ShiftAndAdd());
    }

    IEnumerator ShiftAndAdd()
    {
        for (int i = 0; i < spawnedBricks.Count; i++)
        {
            StartCoroutine(TileDown(spawnedBricks[i].transform));
        }
        yield return new WaitForSeconds(0.7f);
        NewLineSpawner();
    }
    public void ResetRowCount()
    {
        rowsSpawned = 0;
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
    
    
    

    IEnumerator TileDown(Transform startPos)
    {
        Vector3 desiredPos = startPos.position + new Vector3(0, -spacing, 0);
        float elapsedTime = 0f;
        float totalTime = 0.6f;
        while (elapsedTime < totalTime)
        {
            startPos.position = Vector3.Lerp(startPos.position, desiredPos, elapsedTime / totalTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        startPos.position = desiredPos;
    }
}