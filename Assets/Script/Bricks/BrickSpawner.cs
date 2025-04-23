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

    //public void SpawnBrickRow()
    //{
    //    for (int j = 0; j < columns; j++)
    //    {
    //        int randomIndex = Random.Range(0, brickPrefabs.Count);
    //        Vector3 spawnPos = transform.position + new Vector3(j * spacing, 0, 0);

    //        GameObject brickObj = Instantiate(brickPrefabs[randomIndex], spawnPos, Quaternion.identity);
    //        spawnedBricks.Add(brickObj);


    //        int brickValue = Mathf.Max(1, Random.Range(ballMovementScript.presentBallCount, ballMovementScript.presentBallCount + 10));
    //        brickObj.GetComponent<Brick>().SetValue(brickValue);
    //    }
    //}
    public void SpawnBrickRow()
    {
        if (ballMovementScript == null)
        {
            Debug.LogError("Script not assigned!");
            return;
        }

        for (int j = 0; j < columns; j++)
        {
            int randomIndex = Random.Range(0, brickPrefabs.Count);
            Vector3 spawnPos = transform.position + new Vector3(j * spacing, 0, 0);

            GameObject brickObj = Instantiate(brickPrefabs[randomIndex], spawnPos, Quaternion.identity);
            spawnedBricks.Add(brickObj);

            Brick brickComponent = brickObj.GetComponent<Brick>();
            if (brickComponent != null)
            {
                int brickValue = Mathf.Max(1, Random.Range(ballMovementScript.presentBallCount, ballMovementScript.presentBallCount + 10));
                brickComponent.SetValue(brickValue);
            }
            else
            {
             //   Debug.LogError("Brick prefab missing Brick script!");
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
