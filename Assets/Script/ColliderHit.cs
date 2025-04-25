using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
public class ColliderHit : MonoBehaviour
{

    [SerializeField] private int hitTime;
    public ScoreMangaer scoreManager;
    private int _hitCount;
    public GameObject ParentObj;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TMP_Text  BrickValue;
    private float  scoreReduce;
    private int BrickValueInt;
    private int newScore;
    void Start()
    {
     scoreManager.score = 0;
     BrickValueInt = int.Parse(BrickValue.text);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "cloneBall" )
        {
            
            if (_hitCount < hitTime )
            { 
                _hitCount++;
                BrickValueInt--;
                BrickValue.text = BrickValueInt.ToString();
                if(BrickValueInt == 0 )
                {
                    
                    //object destroy  pai error throw kar raha tha toh disable karwake dekh liya
                    ParentObj.SetActive(false);
                   // Destroy(ParentObj); // Parent object destroy hoga jab brick value 0 hojaye toh
               
             
             //Destroy(gameObject); // Destroy agar text value 0 hojaye toh
                    

                    //prefab ke sath clash horaha tha islea disaBLE KIYA
                    // scoreManager.score += 1;
                    // scoreText.text = scoreManager.score.ToString();
                    //
                    // if (scoreManager.score > scoreManager.highscore)
                    // {
                    //     scoreManager.highscore = scoreManager.score;
                    //     highScoreText.text = scoreManager.highscore.ToString();
                    // }
                }
                
                
                
                
                if (collision.gameObject.tag == "Player")
                {
                    Rigidbody2D rigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
                    if (rigidBody.transform.position.y <= -2.78)
                    {
                        transform.Translate(Vector3.down * 2 * Time.deltaTime);
                    }
                }
            }
        }
    }
}
