using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private ScoreMangaer scoreManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

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
        highScore = LoadHighScore(); 
        highScoreText.text = highScore.ToString();
       
    }

    public void Incrementer()
    {
        scoreManager.score += 1;
        scoreText.text = scoreManager.score.ToString();
        Debug.Log("Incremented score: " + scoreManager.score);
        if (scoreManager.score >= highScore)
        {
            highScore = scoreManager.score;
            highScoreText.text = highScore.ToString();
            SaveHighScore(highScore); 
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

    public void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();
    }

    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
    public void SetScore(int score)
    {
        scoreManager.score = score;
        scoreText.text = score.ToString();
    }
    public void UpdateScoreText()
    {
        scoreText.text = scoreManager.score.ToString();
    }

}
