// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
// public class BrickSpawner : MonoBehaviour
// {
//     public RectTransform[] columns; 
//     public BallMovementScript  ballMovement;
//     [Range(0f, 1f)]
//     public float powerUpChance = 0.1f;
//     public float spacing = 0.2f;
//     public List<GameObject> prefabs = new List<GameObject>();
//
//     void Start()
//     {
//         // SpawnRow();
//        Spawn();
//     }
//
//
//     private void Spawn()
//     {
//         for (int i = 0; i < 1; i++)
//         {
//             for (int j = 0; j < 5; j++)
//             {
//                 Vector3 spawnPos = transform.position+new Vector3(j*spacing,i*spacing,0f);
//
//                 GameObject brick = BrickPool.Instance.GetPooledBrick();
//                 brick.transform.position = spawnPos;
//                 if (brick != null)
//                 {
//                     brick.transform.position = spawnPos;
//                     brick.SetActive(true);
//                     int ballCount = ballMovement.presentBallCount;
//                     int brickValue = Random.Range(1, ballCount + 6);
//                     bool isPowerUp = Random.value < powerUpChance;
//
//                     brick.GetComponent<Brick>().Init(brickValue, isPowerUp);
//                 }
//             }
//         }
//     }
//     public void SpawnRow()
//     {
//         foreach (RectTransform column in columns)
//         {
//             GameObject brick = BrickPool.Instance.GetPooledBrick();
//             brick.transform.position = column.position;
//
//             int ballCount = ballMovement.presentBallCount;
//             int brickValue = Random.Range(1, ballCount + 6);
//
//             bool isPowerUp = Random.value < powerUpChance;
//
//             brick.GetComponent<Brick>().Init(brickValue, isPowerUp);
//         }
//     }
// }

using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public List<Transform>  columns = new List<Transform>();
    public BallMovementScript  ballMovement;

    [Range(0f, 1f)]
    public float powerUpChance = 0.1f;

    void Start()
    {
        SpawnRow();
    }

    public void SpawnRow()
    {
        // foreach (Transform column in columns)
        // {
        //     GameObject brick = BrickPool.Instance.GetPooledBrick();
        //     brick.SetActive(true);
        //     brick.transform.position = column.position;
        //     int ballCount = ballMovement.presentBallCount;
        //     int brickValue = Random.Range(1, ballCount + 6);
        //     bool isPowerUp = Random.value < powerUpChance;
        //
        //     brick.GetComponent<Brick>().Init(brickValue, isPowerUp);
        // }


        for (int i = 0; i < columns.Count; i++)
        {
            GameObject brick = BrickPool.Instance.GetPooledBrick();
            brick.transform.position = columns[i].transform.position;
            Debug.Log(brick.transform.position);
            int ballCount = ballMovement.presentBallCount;
            int brickValue = Random.Range(1, ballCount + 6);
            bool isPowerUp = Random.value < powerUpChance;
            brick.GetComponent<Brick>().Init(brickValue, isPowerUp);
        }
        
    }
}