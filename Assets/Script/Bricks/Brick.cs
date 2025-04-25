using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health = 1;
    public TextMeshPro valueText;
    public GameObject ParentObj;
    
    public void SetValue(int value)
    {
        health = value;
        valueText.text = value.ToString();
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("cloneBall"))
        {
            health--;
            valueText.text = health.ToString();
            if (health <= 0)
            {
                  gameObject.SetActive(false);
                      if (valueText != null)
                          valueText.text = "";
                 
            }
            AudioMangerScript.Instance.PlayOneShot(AudioType.BALL);
                //ParentObj.SetActive(false);
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("EndTrigger"))
    //     {
    //         gameObject.SetActive(false);
    //     }
    // }
}



//work
//using TMPro;
//using UnityEngine;

//public class Brick : MonoBehaviour
//{
//    public int health = 1;
//    public TextMeshPro valueText;
//    public GameObject ParentObj;
//    public int scoreValue = 1; // Points awarded for destroying this brick

//    private ScoreMangaer scoreManager; // No need to drag in the Inspector anymore

//    public void SetValue(int value)
//    {
//        health = value;
//        valueText.text = value.ToString();
//    }

//    private void Start()
//    {
//        // Find the ScoreManager instance when this brick is created
//        scoreManager = FindObjectOfType<ScoreMangaer>();
//        if (scoreManager == null)
//        {
//            Debug.LogError("ScoreManager not found in the scene!");
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("cloneBall"))
//        {
//            health--;
//            valueText.text = health.ToString();

//            if (health <= 0)
//            {
//                gameObject.SetActive(false);
//                if (valueText != null)
//                    valueText.text = "";

//                // Increase the score when the brick is destroyed
//                if (scoreManager != null)
//                {
//                    scoreManager.score += scoreValue;
//                    // Assuming ScoreManager has a public method to update the UI:
//                    // scoreManager.UpdateScoreUI();
//                }
//                else
//                {
//                    Debug.LogError("ScoreManager was not found when a brick was destroyed!");
//                }
//            }
//            AudioMangerScript.Instance.PlayOneShot(AudioType.BALL);
//        }
//    }

//    // private void OnTriggerEnter2D(Collider2D collision)
//    // {
//    //     if (collision.gameObject.CompareTag("EndTrigger"))
//    //     {
//    //         gameObject.SetActive(false);
//    //     }
//    // }
//}