using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMultiplierPowerup : MonoBehaviour
{

    private float useTimes = 3;
    public BallMovementScript ballMovementScript;
    // Start is called before the first frame update
    public void Mutiplier()
    {
        if (useTimes >= 0 && !ballMovementScript.isMoving)
        {
         ballMovementScript._ballcount = 60;
         useTimes-- ;
        }
    }
}
