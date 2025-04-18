using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pooledCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public BallMovementScript ballMovement; //because prefab dont take ref
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            gameObject.SetActive(false);
          

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Multiplier")
        {
            ballMovement._ballcount++;
        }
    }
}
