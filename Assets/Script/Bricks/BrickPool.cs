using System.Collections.Generic;
using UnityEngine;

public class BrickPool : MonoBehaviour
{
     public static BrickPool Instance;
     public List<GameObject> brickPool;
     public GameObject brickPrefab;
     public int poolSize ;


    [Header("Powerup")]
    public GameObject powerUpPrefab;
    public List<GameObject> powerUpPool = new List<GameObject>();
    public int powerUpPoolSize = 5;


    void Awake()
     {
         Instance = this;
     }
     void Start()
     {
         brickPool = new List<GameObject>();
         GameObject tmpBrick;
         for (int i = 0; i < poolSize; i++)
         {
             tmpBrick = Instantiate(brickPrefab);
             tmpBrick.SetActive(false);
             brickPool.Add(tmpBrick);
         }

        for (int i = 0; i < powerUpPoolSize; i++)
        {
            GameObject obj = Instantiate(powerUpPrefab);
            obj.SetActive(false);
            powerUpPool.Add(obj);
        }

    }

    public GameObject GetPooledBrick()
     {
         for (int i = 0; i < poolSize; i++)
         {

             
             if (!brickPool[i].activeInHierarchy)
             {
                 return brickPool[i];
             }
         }
         return null;
    }
    public GameObject GetPooledPowerUp()
    {
        foreach (var obj in powerUpPool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }
        return null;
    }
}
