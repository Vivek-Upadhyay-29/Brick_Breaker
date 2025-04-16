using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RandomPrefabGenerator : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public float spacing = 0.2f;
    public int index = 0;
public List<GameObject> prefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        
        // StartCoroutine(GridValue(0));
        //
        
        
        
        
        for (int i = 0; i < 5; i++)//apna y hai ya
        {
            for (int j = 0; j < 5;j++)
            {
        
                int RandomIndex = Random.Range(0, gameObjects.Count);
                Vector3 spawnPosition = transform.position + new Vector3(j * spacing, i*spacing, 0);
                GameObject newObj=  Instantiate(gameObjects[RandomIndex], spawnPosition, Quaternion.identity);
                 prefabs.Add(newObj);
                 //Debug.Log("Prefab " + i + " instantiated at position: " + spawnPosition);
               
                 
            }
        }
        
      //  StartCoroutine( PosChange());
        
        
    }

    IEnumerator PosChange()
    {
        
        yield return new WaitForSeconds(0.5f);

  
            for (int i = 0; i < prefabs.Count; i++)
            {
                Vector3 spawnPosition = transform.position - new Vector3(0, -spacing,0 );
                prefabs[i].transform.position = spawnPosition; 
            }
            
        yield return null;
    }


    IEnumerator GridValue(int  diffcultyIndex)
    {

        diffcultyIndex++;
        Debug.Log(diffcultyIndex);

        if (diffcultyIndex < 1)
        {
            index = Random.Range(0, 2);
        }
        else if (diffcultyIndex is >= 2 and <= 3  )
        {
            
            index = Random.Range(0,3);
        }
        else if ( diffcultyIndex is >= 3 and <= 6)
        {
            
            index = Random.Range(0,5);
        }
         
        for (int i = 0; i < gameObjects.Count; i++)
        { 
            
            for (int j = 0; j < gameObjects.Count - 1; j++)
            {
               
                int RandomIndex = index;
                Vector3 spawnPosition = transform.position + new Vector3(j * spacing, i * spacing, 0);
                GameObject newObj = Instantiate(gameObjects[RandomIndex], spawnPosition, Quaternion.identity);
                Debug.Log(newObj.transform.position);
            }
        }

        if (diffcultyIndex < 6)
        {
            
         yield return StartCoroutine(GridValue(diffcultyIndex));
        }
        
    }
}
