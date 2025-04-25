using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreMangaer", menuName = "ScriptableObjects/Score")]
public class ScoreMangaer : ScriptableObject
{


    public int score = 0;
    public int highscore;



    public void high()
    {
        if(score > highscore)
        {
            highscore = score;
        }
    }
    
}

