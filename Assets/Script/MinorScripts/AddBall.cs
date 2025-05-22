using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.tag == "cloneBall" || collision.gameObject.tag == "brick") 
        {
       
            AudioMangerScript.Instance.PlayOneShot(AudioType.MULTIPLIER);

            gameObject.SetActive(false);
        }
    }
    void Update() {
        
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

}