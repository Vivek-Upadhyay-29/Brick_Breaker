using UnityEngine;

public class BallDownBtnScript : MonoBehaviour
{
    [SerializeField] private BallMovementScript ballMovementScript;
    [SerializeField] private BrickSpawner brickSpawner;
    [SerializeField] private GameObject mainBall;
    [SerializeField] private Rigidbody2D gameball;
 
    
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
                    ball.SetActive(false);
                    
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
    
    }

 
}

