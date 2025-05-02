using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ground : MonoBehaviour
{
    public RandomPrefabGenerator generator;
    public BallMovementScript ballMovement;
    public BrickSpawner brickSpawner;
    public int cloneCount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.tag == "cloneBall")
        {

            bool anyBallActive = false;

            foreach (GameObject ball in ObjectPool.Instance.pooledObjects)
            {
                if (ball.activeInHierarchy)
                {
                    anyBallActive = true;
                    break;
                }
            }

            //fixed this
            if (!anyBallActive && !ballMovement.isMoving)
            {
                ballMovement.ballClone.Clear();
                ballMovement.presentBallCount = 0;
                brickSpawner.MoveDownAndAddNewRow();
            }
        }
       
    }
}

