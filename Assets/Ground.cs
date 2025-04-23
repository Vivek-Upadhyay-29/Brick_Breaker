using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Start is called before the first frame update
public class Ground : MonoBehaviour
{
    public RandomPrefabGenerator generator;
    public BallMovementScript ballMovement;
    public BrickSpawner brickSpawner;
    public int cloneCount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Player")
        // {
        //     Debug.Log(collision.gameObject.name);
        //
        //     // if (ballMovement._isCloned)
        //     // {
        //         generator.MoveDown();
        // //    }
        // }

        if (collision.gameObject.tag == "cloneBall")
        {
            cloneCount++;
            Debug.Log(cloneCount);
            if (cloneCount == ballMovement.presentBallCount)
            {
                ballMovement.ballClone.Clear();
                ballMovement.presentBallCount = 0;
                generator.MoveDown();
                cloneCount = 0;

                //// new wala
                //brickSpawner.MoveBricksDown(1);
                brickSpawner.MoveDownAndAddNewRow();
         
                //// Spawn new row of bricks
                //brickSpawner.SpawnBricks(ballMovement.presentBallCount);
                //}



            }

        }
    }
}

