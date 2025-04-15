using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RandomPrefabGenerator : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public float spacing = 0.2f;
    public ScoreMangaer scoreManager;        
    public TextMeshProUGUI scoreText;       
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < gameObjects.Count; i++)//apna y hai ya
        {
            for (int j = 0; j < gameObjects.Count-1;j++)
            {

                int RandomIndex = Random.Range(0, gameObjects.Count);
                Vector3 spawnPosition = transform.position + new Vector3(j * spacing, i*spacing, 0);
                GameObject newObj=  Instantiate(gameObjects[RandomIndex], spawnPosition, Quaternion.identity);
                //ColliderHit hitScript = newObj.GetComponent<ColliderHit>();
                //hitScript.scoreManager = scoreManager;
                //hitScript.scoreText = scoreText;
                //hitScript.highScoreText = highScoreText;
                //Debug.Log("Prefab " + i + " instantiated at position: " + spawnPosition);
         

            }
           
        }
    }
}
