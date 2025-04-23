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
       

        for (int j = 0; j < columns; j++)
        {
            int brickValue = Random.Range(0, ballMovementScript.presentBallCount +10);

            Vector3 spawnPos = transform.position + new Vector3(j * spacing, 0, 0);

            //GameObject brickObj = Instantiate(brickPrefabs[randomIndex], spawnPos, Quaternion.identity);
            GameObject brickObj = BrickPool.Instance.GetPooledBrick();
           brickObj.SetActive(true);
         brickObj.transform.position = spawnPos;

           Brick brickComponent = brickObj.GetComponent<Brick>();
        brickComponent.SetValue(brickValue);
           if (brickComponent != null)
            {
                
                spawnedBricks.Add(brickObj);
                brickObj.transform.position = spawnPos;
                int brickValue = Random.Range(0, ballMovementScript.presentBallCount +10);
               
                brickComponent.SetValue(brickValue);
                brickObj.SetActive(true);
            }
         
        }
    }


    public void MoveDownAndAddNewRow()
    {
        StartCoroutine(ShiftAndAdd());
    }

    IEnumerator ShiftAndAdd()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (GameObject b in spawnedBricks)
        {
            if (b != null)
                b.transform.position += Vector3.down * spacing;
        }

        SpawnBrickRow(); 
    }
}
