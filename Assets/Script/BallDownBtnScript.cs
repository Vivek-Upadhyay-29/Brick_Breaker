using UnityEngine;

public class BallDownBtnScript : MonoBehaviour
{
    public BallMovementScript ballMovementScript;
    public BrickSpawner brickSpawner;
    public pooledCollision PooledCollision; 
    public GameObject mainBall;
    public float resetDebounceTime = 0.5f;
    private Rigidbody2D gameball;

    
    private void Start()
    {
     
        gameball = mainBall.GetComponent<Rigidbody2D>();
    }

    public void BallDown()
    {
        if (ballMovementScript != null && ballMovementScript.isMoving && brickSpawner != null && mainBall != null)
        {
           
          
            foreach (GameObject ball in ballMovementScript.ballClone)
            {
                if (ball != null && ball.activeInHierarchy)
                {
                    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                    if (rb != null) rb.velocity = Vector2.zero;
                    ball.SetActive(false);
                }
            }
            if (gameball != null)
            {
                gameball.velocity = new Vector2(0f, -5f);         
                gameball.velocity = Vector2.zero;               
            }
            ballMovementScript.presentBallCount = 0;
            ballMovementScript.isMoving = false;
            ballMovementScript.slider.value = 0;
            ballMovementScript.canForceDownBall = true;
            mainBall.transform.position = ballMovementScript.startPos;
            brickSpawner.MoveDownAndAddNewRow();
        }
    
    }

 
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallDownBtnScript : MonoBehaviour
//{
//    // Start is called before the first frame update


//    public BallMovementScript ballMovementScript;
//    public BrickSpawner brickSpawner;
//    public pooledCollision PooledCollision;
//    public GameObject mainBall;
//    // Update is called once per frame
//    public void BallDown()
//    {
//        if (ballMovementScript.isMoving)
//        {
//            // for (int i = 0; i < ballMovementScript.ballClone.Count; i++)
//            // {
//            //     ballMovementScript.ballClone[i].SetActive(false);
//            // }
//            foreach (GameObject ball in ballMovementScript.ballClone)
//            {
//            if (ball.activeInHierarchy)
//            {
//                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
//                if (rb != null) rb.velocity = Vector2.zero;
//                ball.SetActive(false);
//            }
//           }


//            ballMovementScript.presentBallCount = 0;
//            ballMovementScript.isMoving = false;
//            ballMovementScript.slider.value = 0;
//            ballMovementScript.canForceDownBall = true;
//            mainBall.transform.position = ballMovementScript.startPos;
//            brickSpawner.MoveDownAndAddNewRow();
//        }
//    }
//}


//up ma

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallDownBtnScript : MonoBehaviour
//{
//    // Start is called before the first frame update


//    public BallMovementScript ballMovementScript;
//    public BrickSpawner brickSpawner;
//    public GameObject mainBall;
//    // Update is called once per frame
//    public void BallDown()
//    {
//        if (ballMovementScript.isMoving)
//        {
//            for (int i = 0; i < ballMovementScript.ballClone.Count; i++)
//            {
//                ballMovementScript.ballClone[i].SetActive(false);
//            }
//            ballMovementScript.ballClone.Clear();
//            ballMovementScript.presentBallCount = 0;
//            ballMovementScript.sliderValue = 0;
//            brickSpawner.MoveDownAndAddNewRow();

//            //mainBall.transform.position = ballMovementScript.startPos;
//            mainBall.transform.position = new Vector3(-0.007f, -3.117f, 0);

//            Rigidbody2D mainRb = mainBall.GetComponent<Rigidbody2D>();
//            if (mainRb != null) mainRb.velocity = Vector2.zero;


//        }
//    }
//}


////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

////public class BallDownBtnScript : MonoBehaviour
////{
////    public BallMovementScript ballMovementScript;
////    public BrickSpawner brickSpawner;
////    public GameObject mainBall;
////    // Update is called once per frame
////    public void BallDown()
////    {
////        if (ballMovementScript.isMoving)
////        {
////            for (int i = 0; i < ballMovementScript.ballClone.Count; i++)
////            {
////                ballMovementScript.ballClone[i].SetActive(false);
////            }
////            ballMovementScript.ballClone.Clear();
////            ballMovementScript.presentBallCount = 0;
////            brickSpawner.MoveDownAndAddNewRow();

////            mainBall.transform.position = ballMovementScript.startPos;
////            //  mainBall.transform.position = new Vector3(-0.007f, -3.117f, 0);
////            Rigidbody2D mainRb = mainBall.GetComponent<Rigidbody2D>();
////            mainRb.velocity = Vector2.zero;

////        }
////    }
////}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallDownBtnScript : MonoBehaviour
//{
//    public BallMovementScript ballMovementScript;
//    public BrickSpawner brickSpawner;
//    public GameObject mainBall;

//    public void BallDown()
//    {
//        if (!ballMovementScript.isMoving) return;

//        foreach (GameObject ball in ballMovementScript.ballClone)
//        {
//            if (ball.activeInHierarchy)
//            {
//                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
//                if (rb != null) rb.velocity = Vector2.zero;
//                ball.SetActive(false);
//            }
//        }

//        ballMovementScript.ballClone.Clear();
//        ballMovementScript.presentBallCount = 0;
//        ballMovementScript.isMoving = false;
//        ballMovementScript.canForceDownBall = true;

//        brickSpawner.MoveDownAndAddNewRow();

//        mainBall.transform.position = ballMovementScript.startPos;
//        Rigidbody2D mainRb = mainBall.GetComponent<Rigidbody2D>();
//        if (mainRb != null) mainRb.velocity = Vector2.zero;


//    }
//}
