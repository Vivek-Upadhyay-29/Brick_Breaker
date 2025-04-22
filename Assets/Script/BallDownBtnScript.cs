using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDownBtnScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    public BallMovementScript ballMovementScript;
    public RandomPrefabGenerator generator;
    public pooledCollision PooledCollision;
    public GameObject mainBall;
    // Update is called once per frame
    public void BallDown()
    {
        if (ballMovementScript.isMoving)
        {
        for (int i = 0; i < ballMovementScript.ballClone.Count; i++)
        {
          ballMovementScript.ballClone[i].SetActive(false);
        }
        ballMovementScript.ballClone.Clear();
        generator.MoveDown();
        
        mainBall.transform.position = new Vector3(-0.007f, -3.117f, 0);
        }
    }
}
