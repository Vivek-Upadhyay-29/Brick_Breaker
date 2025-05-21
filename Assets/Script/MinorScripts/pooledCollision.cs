// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//  
// public class pooledCollision : MonoBehaviour
// {
//     [SerializeField] private BallMovementScript ballMovement;
//  
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("ground"))
//         {
//             StartCoroutine(MoveToResetPositionAndDeactivate());
//         }
//  
//         if (collision.gameObject.CompareTag("WallCollider"))
//         {
//             AudioMangerScript.Instance.PlayOneShot(AudioType.WALLHIT);
//         }
//     }
//  
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("Multiplier"))
//         {
//             ScoreScript.Instance.BallCountText();
//         }
//     }
//  
//     private IEnumerator MoveToResetPositionAndDeactivate()
//     {
//         Vector3 targetPosition = ScoreScript.Instance.resetPosition.position;
//         float speed = 10f;
//  
//         while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
//         {
//             transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
//             yield return null;
//         }
//  
//      
//         transform.position = targetPosition;
//         gameObject.SetActive(false);
//     }
// }



// using System.Collections;
// using UnityEngine;
//  
// public class pooledCollision : MonoBehaviour
// {
//     [SerializeField] private BallMovementScript ballMovement;
//     private Rigidbody2D rb;
//  
//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }
//  
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("ground"))
//         {
//             StartCoroutine(MoveToResetPos());
//         }
//  
//         if (collision.gameObject.CompareTag("WallCollider"))
//         {
//             AudioMangerScript.Instance.PlayOneShot(AudioType.WALLHIT);
//         }
//     }
//  
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("Multiplier"))
//         {
//             ScoreScript.Instance.BallCountText();
//         }
//     }
//  
//     private IEnumerator MoveToResetPos()
//     {
//         Vector3 targetPosition = ScoreScript.Instance.resetPosition.position;
//         float speed = 5f;
//         rb.velocity = Vector2.zero;
//       // rb.angularVelocity = 0f;
//         rb.isKinematic = true;
//         
//         while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
//         {
//             transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
//             yield return null;
//         }
//  
//         transform.position = targetPosition;
//         rb.isKinematic = false;
//         gameObject.SetActive(false);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pooledCollision : MonoBehaviour
{
  
    [SerializeField] private  BallMovementScript ballMovement;
    private Rigidbody2D rb;


    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        { 
           // gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("WallCollider"))
        {
            AudioMangerScript.Instance.PlayOneShot(AudioType.WALLHIT);
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Multiplier")
        {
            
            ScoreScript.Instance.BallCountText();
        }
    }

  
}

