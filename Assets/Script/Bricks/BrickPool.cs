using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPool : MonoBehaviour
{
     public static BrickPool Instance;
     public List<GameObject> brickPool;
     public GameObject brickPrefab;
     public int poolSize ;

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
     }

     public GameObject GetPooledBrick()
     {
         for (int i = 0; i <= poolSize; i++)
         {

             
             if (!brickPool[i].activeInHierarchy)
             {
                 return brickPool[i];
             }
         }
         return null;
     
     }
}
