using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
public class ColliderHit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int hitTime;
    public ScoreMangaer scoreManager;
    private int _hitCount;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshPro  BrickValue;
    private float  scoreReduce;
     private float newScore;
    void Start()
    {
     scoreManager.score = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _hitCount < hitTime)
        {
            _hitCount++;
            Debug.Log(_hitCount);
            if (_hitCount == hitTime)
            {
                scoreManager.score += 1;
               
                scoreReduce -= 1;
                scoreText.text = scoreManager.score.ToString(); 
                newScore = hitTime + scoreReduce;
                BrickValue.text =newScore.ToString();
                if (scoreManager.score > scoreManager.highscore)
                {
                    scoreManager.highscore = scoreManager.score;
                    highScoreText.text = scoreManager.highscore.ToString();
                }
                Destroy(gameObject);
            }
        }
        
        else if (collision.gameObject.tag == "Player" && hitTime == _hitCount)
        {
            scoreReduce -= 1;
            scoreText.text = scoreManager.score.ToString(); 
            newScore = hitTime + scoreReduce;
            BrickValue.text =newScore.ToString();
            
            Destroy(gameObject);
            
            
            
            
          scoreManager.score += 1;
          scoreText.text = scoreManager.score.ToString();
         if (scoreManager.score > scoreManager.highscore)
         {
             scoreManager.highscore = scoreManager.score;
             highScoreText.text = scoreManager.highscore.ToString();
         }
        }
    }
}
