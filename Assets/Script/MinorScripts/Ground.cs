using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Ground : MonoBehaviour
{
    
    [SerializeField] private  BallMovementScript ballMovement;
    [SerializeField] private  BrickSpawner brickSpawner;
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

