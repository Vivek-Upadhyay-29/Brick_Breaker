using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomPrefabGenerator : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public float spacing = 0.2f;
    public List<GameObject> prefabs = new List<GameObject>();
    
    public int index = 0;
    public Ground ground;
    public bool IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        IsGrounded = false;
        for (int i = 0; i < 1; i++) //apna y hai ya
        {
            for (int j = 0; j < 5; j++)
            {

                int RandomIndex = Random.Range(0, gameObjects.Count);
                Vector3 spawnPosition = transform.position + new Vector3(j * spacing, i * spacing, 0);
                GameObject newObj = Instantiate(gameObjects[RandomIndex], spawnPosition, Quaternion.identity);
                prefabs.Add(newObj);
                //Debug.Log("Prefab " + i + " instantiated at position: " + spawnPosition);
            }
        }
    }


    public void MoveDown()
    {
        StartCoroutine(PosChange());

    }

    IEnumerator PosChange()
    {
        yield return new WaitForSeconds(0.5f); 
        for (int i = 0; i < prefabs.Count; i++)
        {
            Vector3 newPos = prefabs[i].transform.position + new Vector3(0, -spacing, 0);
            prefabs[i].transform.position = newPos;
        }
        //this for adding new row when grid moves down
        for (int j = 0; j < 5; j++)
        {

            int RandomIndex = Random.Range(0, gameObjects.Count);
            Vector3 spawnPosition = transform.position + new Vector3(j * spacing, 0, 0);
            GameObject newObj = Instantiate(gameObjects[RandomIndex], spawnPosition, Quaternion.identity);
            prefabs.Add(newObj);
           
        }

        IsGrounded = false;
        yield return null;
    }
}
