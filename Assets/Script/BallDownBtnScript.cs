// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using Image = UnityEngine.UI.Image;
//
// public class BallDownBtnScript : MonoBehaviour
// {
//     [SerializeField] private BallMovementScript ballMovementScript;
//     [SerializeField] private BrickSpawner brickSpawner;
//     [SerializeField] private GameObject mainBall;
//     [SerializeField] private Rigidbody2D gameball;
//     [SerializeField] private Image balldownSprite;
//     [SerializeField] private Button btn;
//     
//     private void Start()
//     {
//         gameball = mainBall.GetComponent<Rigidbody2D>();
//
//     }
//
//
//
//     public void BallDown()
//     {
//         
//         
//         bool anyBallActive = false;
//
//         foreach (GameObject ball in ObjectPool.Instance.pooledObjects)
//         {
//             if (ball.activeInHierarchy)
//             {
//                 anyBallActive = true;
//                 break;
//             }
//         }
//         
//         if (ballMovementScript.isMoving || anyBallActive)
//         {
//             foreach (GameObject ball in ballMovementScript.ballClone)
//             {
//                 if (ball != null && ball.activeInHierarchy)
//                 {
//                     Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
//                      rb.velocity = Vector2.zero;
//                   //   balldownSprite.enabled = false;
//                      //btn.interactable = false;
//                      StartCoroutine(MoveToResetPos(rb));
//                 }
//             }
//           
//             gameball.velocity = new Vector2(0f, -5f);         
//             gameball.velocity = Vector2.zero;               
//             
//             ballMovementScript.presentBallCount = 0;
//             ballMovementScript.isMoving = false;
//             ballMovementScript.slider.value = 0;
//             ballMovementScript.canForceDownBall = true;
//             mainBall.transform.position = ballMovementScript.startPos;
//             brickSpawner.MoveDownAndAddNewRow();
//         }
//
//         IEnumerator MoveToResetPos(Rigidbody2D rigidbody2D)
//     {
//         AudioMangerScript.Instance.PlayOneShot(AudioType.BALLDOWNBTN);
//        
//         Rigidbody2D rb1 = rigidbody2D;
//         Vector3 targetPosition = ScoreScript.Instance.resetPosition.position;
//         float speed = 5f;
//         rb1.velocity = Vector2.zero;
//         rb1.angularVelocity = 0f;
//         rb1.isKinematic = true;
//          
//         while (Vector3.Distance(rb1.transform.position, targetPosition) > 0.05f)
//         {
//             rb1.transform.position = Vector3.MoveTowards(rb1.position, targetPosition, speed * Time.deltaTime);
//             yield return null;
//         }
//   
//         rb1.transform.position = targetPosition;
//         rb1.isKinematic = false;
//        // balldownSprite.enabled = true;
//        // btn.interactable = true;
//         rb1.gameObject.SetActive(false);
//         
//      
//       }
//     }
//    
//  
// }
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class BallDownBtnScript : MonoBehaviour
{
    [SerializeField] private BallMovementScript ballMovementScript;
    [SerializeField] private BrickSpawner brickSpawner;
    [SerializeField] private GameObject mainBall;
    [SerializeField] private Rigidbody2D gameball;
    [SerializeField] private Image balldownSprite;
 
    
    private void Start()
    {
        gameball = mainBall.GetComponent<Rigidbody2D>();

    }



    public void BallDown()
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
        
        if (ballMovementScript.isMoving || anyBallActive)
        {
            foreach (GameObject ball in ballMovementScript.ballClone)
            {
                if (ball != null && ball.activeInHierarchy)
                {
                    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                     rb.velocity = Vector2.zero;
                     StartCoroutine(MoveToResetPos(rb));
                }
            }
          
            gameball.velocity = new Vector2(0f, -5f);         
            gameball.velocity = Vector2.zero;               
            
            ballMovementScript.presentBallCount = 0;
            ballMovementScript.isMoving = false;
            ballMovementScript.slider.value = 0;
            ballMovementScript.canForceDownBall = true;
            mainBall.transform.position = ballMovementScript.startPos;
            brickSpawner.MoveDownAndAddNewRow();
        }

        IEnumerator MoveToResetPos(Rigidbody2D rigidbody2D)
    {
        AudioMangerScript.Instance.PlayOneShot(AudioType.BALLDOWNBTN);
        Rigidbody2D rb1 = rigidbody2D;
        Vector3 targetPosition = ScoreScript.Instance.resetPosition.position;
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
        
     
      }
    }
   
 
}

