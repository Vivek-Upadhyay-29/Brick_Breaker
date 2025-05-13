using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallCount : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private BallMovementScript ballMovementScript;

    void Start()
    {
        text.text = "";
    }
    private void Update()
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
        if (anyBallActive)
        {
            int ballCount = ballMovementScript._ballcount + 1;
            text.text = ballCount.ToString() +"X"; 
        }
        // else
        // {
        //     text.text = "";
        // }
    }
}