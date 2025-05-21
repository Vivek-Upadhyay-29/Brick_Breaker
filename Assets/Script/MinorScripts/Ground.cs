//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;


//public class Ground : MonoBehaviour
//{

//    private Rigidbody2D rb;

//    [SerializeField] private  BallMovementScript ballMovement;
//    [SerializeField] private  BrickSpawner brickSpawner;
//    [SerializeField] private Vector3 newBallPosition;

//    private void OnCollisionEnter2D(Collision2D collision)
//    {

//        if (collision.gameObject.tag == "cloneBall")
//        {


//            rb = collision.gameObject.GetComponent<Rigidbody2D>();
//            StartCoroutine(MoveToResetPos(rb));
//            // newBallPosition  = rb.transform.position ;
//        }

//    } 
//    private IEnumerator MoveToResetPos(Rigidbody2D rigidbody2D)
//    {
//        Rigidbody2D rb1 = rigidbody2D;
//    //    Vector3 targetPosition = ScoreScript.Instance.resetPosition.position;
//       Vector3 targetPosition = new Vector3(ballMovement.transform.position.x , -3.12f);
//        float speed = 5f;
//        rb1.velocity = Vector2.zero;
//        rb1.angularVelocity = 0f;
//        rb1.isKinematic = true;

//        while (Vector3.Distance(rb1.transform.position, targetPosition) > 0.05f)
//        {
//            rb1.transform.position = Vector3.MoveTowards(rb1.position, targetPosition, speed * Time.deltaTime);
//            yield return null;
//        }

//        rb1.transform.position = targetPosition;
//        rb1.isKinematic = false;
//        rb1.gameObject.SetActive(false);

//        bool anyBallActive = false;

//        foreach (GameObject ball in ObjectPool.Instance.pooledObjects)
//        {
//            if (ball.activeInHierarchy)
//            {
//                anyBallActive = true;
//                break;
//            }
//        }
//        if (!anyBallActive && !ballMovement.isMoving)
//        {

//            ballMovement.ballClone.Clear();
//            ballMovement.presentBallCount = 0;
//            brickSpawner.MoveDownAndAddNewRow();
//        }
//    }
//}




//private IEnumerator MoveToResetPos(Rigidbody2D rb1)
//{
//    Vector3 targetPosition = new Vector3(ballMovement.transform.position.x, -3.12f);
//    float speed = 5f;

//    rb1.velocity = Vector2.zero;
//    rb1.angularVelocity = 0f;
//    rb1.isKinematic = true;

//    while (Vector3.Distance(rb1.transform.position, targetPosition) > 0.05f)
//    {
//        rb1.transform.position = Vector3.MoveTowards(rb1.position, targetPosition, speed * Time.deltaTime);
//        yield return null;
//    }

//    rb1.transform.position = targetPosition;
//    rb1.isKinematic = false;
//    rb1.gameObject.SetActive(false);
//   yield return new WaitForEndOfFrame();
//  ballMovement.CheckAllBallsStoppedAndMoveBricks(brickSpawner);
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private BallMovementScript ballMovement;
    [SerializeField] private BrickSpawner brickSpawner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloneBall"))
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            StartCoroutine(MoveToResetPos(rb));
        }
    }
    private IEnumerator MoveToResetPos(Rigidbody2D rigidbody2D)
    {
        Rigidbody2D rb1 = rigidbody2D;
        //    Vector3 targetPosition = ScoreScript.Instance.resetPosition.position;
        Vector3 targetPosition = new Vector3(ballMovement.transform.position.x , -3.12f);
        float speed = 5f;
        rb1.velocity = Vector2.zero;
        rb1.angularVelocity = 0f;
        rb1.isKinematic = true;
         
        while (Vector3.Distance(rb1.transform.position, targetPosition) > 0.05f)
        {
            rb1.transform.position = Vector3.MoveTowards(rb1.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
  
        rb1.transform.position = targetPosition;
        rb1.isKinematic = false;
        rb1.gameObject.SetActive(false);
        
        bool anyBallActive = false;
    
        foreach (GameObject ball in ObjectPool.Instance.pooledObjects)
        {
            if (ball.activeInHierarchy)
            {
                anyBallActive = true;
                break;
            }
        }
        if (!anyBallActive && !ballMovement.isMoving)
        {
                
            ballMovement.ballClone.Clear();
            ballMovement.presentBallCount = 0;
           
            brickSpawner.MoveDownAndAddNewRow();
        }
    }
    
    
    
  // private IEnumerator MoveToResetPos(Rigidbody2D rb1)
  //   {
  //       Vector3 targetPosition = new Vector3(ballMovement.transform.position.x, -3.12f);
  //       float speed = 5f;
  //
  //       rb1.velocity = Vector2.zero;
  //       rb1.angularVelocity = 0f;
  //       rb1.isKinematic = true;
  //
  //       while (Vector3.Distance(rb1.transform.position, targetPosition) > 0.05f)
  //       {
  //           rb1.transform.position = Vector3.MoveTowards(rb1.position, targetPosition, speed * Time.deltaTime);
  //           yield return null;
  //       }
  //
  //       rb1.transform.position = targetPosition;
  //       rb1.isKinematic = false;
  //       rb1.gameObject.SetActive(false);
  //
  //       yield return null;
  //
  //       ballMovement.CheckAllBallsStoppedAndMoveBricks(brickSpawner);
  //       
  //   }

}
