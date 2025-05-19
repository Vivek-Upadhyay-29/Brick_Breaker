using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private  ScoreMangaer scoreManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField]private int newScore;
    public static ScoreScript Instance;
    public int highScore = 0;

    public Transform resetPosition;
    public int newBallCountforprefab = 0;
    public int MinBrickValue = 0;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {

        Reset();
    }
    // Update is called once per frame
    public void Incrementer()
    {
        scoreManager.score += 1;
        scoreText.text = scoreManager.score.ToString();

        if (scoreManager.score  >= int.Parse(highScoreText.text) )
        {
            scoreManager.highscore = scoreManager.score;
            highScoreText.text = scoreManager.highscore.ToString();
        }
    }
    
    
    public int GetHighScore()
    {
        return highScore;
    }
    public int GetCurrentScore()
    {
        return scoreManager.score;
    }


    public void Reset()
    {
        scoreManager.score = 0;
        scoreText.text = scoreManager.score.ToString();
        
    }


    public int BallCountText()
    {
        newBallCountforprefab++;
        return newBallCountforprefab;
    }
    
}