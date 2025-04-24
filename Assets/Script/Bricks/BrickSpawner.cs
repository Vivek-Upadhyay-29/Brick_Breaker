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
    [Range(0, 1f)] public float powerUpSpawnChance = 1;



    void Start()
    {
        SpawnBrickRow();
    }

    public void SpawnBrickRow()
    {

        for (int i = 0; i < 2; i++)
        {
            
         for (int j = 0; j < columns; j++)
         {
            int brickValue = Random.Range(0, ballMovementScript._ballcount +8);
            
            Vector3 spawnPos = transform.position + new Vector3(j * spacing, i*-spacing, 0);
            
            GameObject brickObj = BrickPool.Instance.GetPooledBrick();
            brickObj.transform.position = spawnPos;
            spawnedBricks.Add(brickObj);
            
            Brick brickComponent = brickObj.GetComponent<Brick>();
            brickComponent.SetValue(brickValue);
            
            //this for spawning empty  obj
            brickObj.SetActive(brickValue != 0);

                //this for powerup
                if (Random.value < powerUpSpawnChance)
                {
                    GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();

                    if (powerUp != null)
                    {
                        powerUp.transform.SetParent(brickObj.transform); 
                        powerUp.transform.localPosition = new Vector3(0, -0.2f, 0); 
                        powerUp.SetActive(true);
                    }
                }
            }
        }
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

    private void NewLineSpawner()
    {
        for (int j = 0; j < columns; j++)
        {
            int brickValue = Random.Range(0, ballMovementScript._ballcount +8);
            
            Vector3 spawnPos = transform.position + new Vector3(j * spacing, 0, 0);
            
            GameObject brickObj = BrickPool.Instance.GetPooledBrick();
            brickObj.transform.position = spawnPos;
            spawnedBricks.Add(brickObj);
            Brick brickComponent = brickObj.GetComponent<Brick>();
            brickComponent.SetValue(brickValue);
            //for empty obj
            brickObj.SetActive(brickValue != 0);
            // for powerup
            if (Random.value < powerUpSpawnChance)
            {
                GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();

                if (powerUp != null)
                {
                    powerUp.transform.SetParent(brickObj.transform); 
                    powerUp.transform.localPosition = new Vector3(0, -0.2f, 0); 
                    powerUp.SetActive(true);
                }
            }
        }
    }
     IEnumerator TileDown(Transform startPos)
    {
        Vector3 desiredPos = startPos.position + new Vector3(0, -spacing, 0);
        float elapsedTime = 0f;
        float totalTime = 0.6f;
        while (elapsedTime < totalTime)
        {
            startPos.position= Vector3.Lerp(startPos.position , desiredPos, elapsedTime / totalTime);
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            yield return null;
        }
        startPos.position = desiredPos;
    }
}

