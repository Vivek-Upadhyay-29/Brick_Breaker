using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.tag == "cloneBall" || collision.CompareTag("brick")) 
        {
       
            gameObject.SetActive(false); // Deactivate the power-up after the ball collects it
        }
    }
}