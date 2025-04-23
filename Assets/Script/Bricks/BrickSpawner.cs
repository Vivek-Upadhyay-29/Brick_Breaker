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

    void Start()
    {
        SpawnBrickRow();
    }

    public void SpawnBrickRow()
    {
     
        for (int i = 0; i < columns; i++)
         for (int j = 0; j < columns; j++)
         {
            int brickValue = Random.Range(1, ballMovementScript._ballcount +8);
            
            Vector3 spawnPos = transform.position + new Vector3(j * spacing, 0, 0);
            
            GameObject brickObj = BrickPool.Instance.GetPooledBrick();
            brickObj.transform.position = spawnPos;
            spawnedBricks.Add(brickObj);
            Brick brickComponent = brickObj.GetComponent<Brick>();
            brickComponent.SetValue(brickValue);
            brickObj.SetActive(true);
         }
        
    }

    public void MoveDownAndAddNewRow()
    {
        StartCoroutine(ShiftAndAdd());
        
    }

    IEnumerator ShiftAndAdd()
    {
        // Move brick down
        // for (int i = 0; i < spawnedBricks.Count; i++)
        // {
        //     Vector3 spawnPos = spawnedBricks[i].transform.position + new Vector3(0,-spacing, 0);
        //     spawnedBricks[i].transform.position = spawnPos;
        //     // spawnedBricks[i].transform.position += Vector3.down * spacing;
        // }
        //  
        // SpawnBrickRow();

        for (int i = 0; i < spawnedBricks.Count; i++)
        {
            StartCoroutine(TileDown(spawnedBricks[i].transform));
        }
        yield return new WaitForSeconds(0.7f);
        SpawnBrickRow();
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
    }
}

