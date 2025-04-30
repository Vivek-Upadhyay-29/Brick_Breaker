using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallMultiplierPowerup : MonoBehaviour
{
    public int _useTimes = 2;
    public BallMovementScript ballMovementScript;
    public TextMeshProUGUI textMesh;


    void Start()
    {
        textMesh.text = _useTimes.ToString();
    }
    public void Multiplier()
    {
        if (_useTimes >0 && !ballMovementScript.isMoving)
        {
            

            int originalCount = ballMovementScript._ballcount;
            ballMovementScript._ballcount = 10;
            _useTimes--;
            textMesh.text = _useTimes.ToString();
            ballMovementScript.StartCoroutine(RestoreAfterShoot(originalCount));
        }
    }
    private IEnumerator RestoreAfterShoot(int originalCount)
    {
        
        yield return new WaitUntil(() => ballMovementScript.isMoving);
        yield return new WaitUntil(() => !ballMovementScript.isMoving);

        ballMovementScript._ballcount = originalCount;
    }

    // private IEnumerator RestoreAfterShoot(int originalCount)
    // {
    //     yield return new WaitUntil(() => !ballMovementScript.isMoving);
    //
    //     ballMovementScript._ballcount = originalCount;
    // }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class BallMultiplierPowerup : MonoBehaviour
// {
//
//     private float useTimes = 3;
//     public BallMovementScript ballMovementScript;
//     // Start is called before the first frame update
//     public void Mutiplier()
//     {
//         if (useTimes >= 0 && !ballMovementScript.isMoving)
//         {
//             ballMovementScript._ballcount = 60;
//             useTimes-- ;
//         }
//     }
// }
