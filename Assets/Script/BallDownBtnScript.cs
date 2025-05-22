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



using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallDownBtnScript : MonoBehaviour
{
    [SerializeField] private BallMovementScript ballMovementScript;
    [SerializeField] private BrickSpawner brickSpawner;
    [SerializeField] private GameObject mainBall;
    [SerializeField] private Image balldownSprite;
    [SerializeField] private Button ballDownButton;

    private Rigidbody2D gameball;
    private float nextAvailableTime = 0f;
    private float cooldownDuration = 3f;

    private void Start()
    {
        gameball = mainBall.GetComponent<Rigidbody2D>();
        ballDownButton.interactable = true;
    }

    private void Update()
    {
        if (!ballDownButton.interactable && Time.time >= nextAvailableTime)
        {
            ballDownButton.interactable = true;
        }
    }

    public void BallDown()
    {
        if (Time.time < nextAvailableTime) return;

        ballDownButton.interactable = false;
        nextAvailableTime = Time.time + cooldownDuration;

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
                    MoveToResetPos(rb);
                }
            }

            gameball.velocity = Vector2.zero;
            mainBall.transform.position = ballMovementScript.startPos;

            ballMovementScript.presentBallCount = 0;
            ballMovementScript.isMoving = false;
            ballMovementScript.slider.value = 0;
            ballMovementScript.canForceDownBall = true;
            ballMovementScript.ballClone.Clear();

            brickSpawner.MoveDownAndAddNewRow();
        }
    }

    private void MoveToResetPos(Rigidbody2D rb)
    {
        Vector3 targetPosition = ScoreScript.Instance.resetPosition.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.transform.position = targetPosition;
        rb.gameObject.SetActive(false);
        AudioMangerScript.Instance.PlayOneShot(AudioType.BALLDOWNBTN);
    }
}





























































//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class BallDownBtnScript : MonoBehaviour
//{
//    [SerializeField] private BallMovementScript ballMovementScript;
//    [SerializeField] private BrickSpawner brickSpawner;
//    [SerializeField] private GameObject mainBall;
//    [SerializeField] private Image balldownSprite;
//    [SerializeField] private Button ballDownButton;

//    private Rigidbody2D gameball;
//    private float nextAvailableTime = 0f;
//    private float cooldownDuration = 3f;

//    private void Start()
//    {
//        gameball = mainBall.GetComponent<Rigidbody2D>();
//        ballDownButton.interactable = true;
//    }

//    private void Update()
//    {
//        if (!ballDownButton.interactable && Time.time >= nextAvailableTime)
//        {
//            ballDownButton.interactable = true;
//        }
//    }

//    public void BallDown()
//    {
//        if (Time.time < nextAvailableTime) return;

//        ballDownButton.interactable = false;
//        nextAvailableTime = Time.time + cooldownDuration;

//        bool anyBallActive = false;
//        foreach (GameObject ball in ObjectPool.Instance.pooledObjects)
//        {
//            if (ball.activeInHierarchy)
//            {
//                anyBallActive = true;
//                break;
//            }
//        }

//        if (ballMovementScript.isMoving || anyBallActive)
//        {
//            foreach (GameObject ball in ballMovementScript.ballClone)
//            {
//                if (ball != null && ball.activeInHierarchy)
//                {
//                    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
//                    StartCoroutine(MoveToResetPos(rb));
//                }
//            }

//            gameball.velocity = Vector2.zero;
//            mainBall.transform.position = ballMovementScript.startPos;

//            ballMovementScript.presentBallCount = 0;
//            ballMovementScript.isMoving = false;
//            ballMovementScript.slider.value = 0;
//            ballMovementScript.canForceDownBall = true;
//            ballMovementScript.ballClone.Clear();

//            brickSpawner.MoveDownAndAddNewRow();
//        }
//    }

//    private IEnumerator MoveToResetPos(Rigidbody2D rb)
//    {
//        AudioMangerScript.Instance.PlayOneShot(AudioType.BALLDOWNBTN);

//        Vector3 targetPosition = ScoreScript.Instance.resetPosition.position;
//        float speed = 5f;

//        rb.velocity = Vector2.zero;
//        rb.angularVelocity = 0f;
//        rb.isKinematic = true;

//        while (Vector3.Distance(rb.transform.position, targetPosition) > 0.05f)
//        {
//            rb.transform.position = Vector3.MoveTowards(rb.transform.position, targetPosition, speed * Time.deltaTime);
//            yield return null;
//        }

//        rb.transform.position = targetPosition;
//        rb.isKinematic = false;
//        rb.gameObject.SetActive(false);
//    }
//}
