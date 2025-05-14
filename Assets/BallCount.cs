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
        // text.text = "";
    }
    private void Update()
    { 
        
        int newBallCount = ScoreScript.Instance.newBallCountforprefab;
        
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
            text.text = "";
        }
        else
        {
            int ballCount = ballMovementScript._ballcount + 1 + newBallCount; ;
            text.text = ballCount.ToString() +"X";
           
        }
    }
}