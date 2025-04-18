using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    // Start is called before the first frame update

   //this is for ball multipler prefab

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
