//using System.Collections.Generic;
//using UnityEngine;

//public class BrickPool : MonoBehaviour
//{
//     public static BrickPool Instance;
//     public List<GameObject> brickPool;
//     public GameObject brickPrefab;
//     public int poolSize ;


//    [Header("Powerup")]
//    public GameObject powerUpPrefab;
//    public List<GameObject> powerUpPool = new List<GameObject>();
//    public int powerUpPoolSize = 5;


//    void Awake()
//     {
//         Instance = this;
//     }
//     void Start()
//     {
//         brickPool = new List<GameObject>();
//         GameObject tmpBrick;
//         for (int i = 0; i < poolSize; i++)
//         {
//             tmpBrick = Instantiate(brickPrefab);
//             tmpBrick.SetActive(false);
//             brickPool.Add(tmpBrick);
//         }

//        for (int i = 0; i < powerUpPoolSize; i++)
//        {
//            GameObject obj = Instantiate(powerUpPrefab);
//            obj.SetActive(false);
//            powerUpPool.Add(obj);
//        }

//    }

//    public GameObject GetPooledBrick()
//     {
//         for (int i = 0; i < poolSize; i++)
//         {


//             if (!brickPool[i].activeInHierarchy)
//             {
//                 return brickPool[i];
//             }
//         }
//         return null;
//    }
//    public GameObject GetPooledPowerUp()
//    {
//        foreach (var obj in powerUpPool)
//        {
//            if (!obj.activeInHierarchy)
//                return obj;
//        }
//        return null;
//    }
//}
using System.Collections.Generic;
using UnityEngine;

public class BrickPool : MonoBehaviour
{
    public static BrickPool Instance;

    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private int initialPoolSize = 1000;

    public List<GameObject> pooledBricks = new List<GameObject>();
    public List<GameObject> pooledPowerUps = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject brick = Instantiate(brickPrefab);
            brick.SetActive(false);
            pooledBricks.Add(brick);

            GameObject powerup = Instantiate(powerUpPrefab);
            powerup.SetActive(false);
            pooledPowerUps.Add(powerup);
        }
    }

    public GameObject GetPooledBrick()
    {
        foreach (var brick in pooledBricks)
        {
            if (!brick.activeInHierarchy)
            {
                return brick;
            }
        }
    GameObject newBrick = Instantiate(brickPrefab);
        newBrick.SetActive(false);
        pooledBricks.Add(newBrick);
        return newBrick;
    }

    public GameObject GetPooledPowerUp()
    {
        foreach (var powerup in pooledPowerUps)
        {
            if (!powerup.activeInHierarchy)
            {
                return powerup;
            }
        }

        GameObject newPowerUp = Instantiate(powerUpPrefab);
        newPowerUp.SetActive(false);
        pooledPowerUps.Add(newPowerUp);
        return newPowerUp;
    }
}

