using System.Collections;
using UnityEngine;

public class BallMultiplierPowerup : MonoBehaviour
{
    private int useTimes = 2;
    public BallMovementScript ballMovementScript;

    public void Multiplier()
    {
        if (useTimes > 0 && !ballMovementScript.isMoving)
        {
            useTimes--;

            int originalCount = ballMovementScript._ballcount;
            ballMovementScript._ballcount = 30;

            ballMovementScript.StartCoroutine(RestoreAfterShoot(originalCount));
        }
    }

    private IEnumerator RestoreAfterShoot(int originalCount)
    {
        yield return new WaitUntil(() => !ballMovementScript.isMoving);

        ballMovementScript._ballcount = originalCount;
    }
}
