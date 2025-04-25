//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Random = UnityEngine.Random;

//public class BrickSpawner : MonoBehaviour
//{
//    public List<GameObject> brickPrefabs = new List<GameObject>();
//    public float spacing = 0.8f;
//    public List<GameObject> spawnedBricks = new List<GameObject>();
//    public BallMovementScript ballMovementScript;
//    public int columns = 5;
//    [Range(0, 1f)] public float powerUpSpawnChance = 0.1f; // Adjust this chance for power-ups on regular bricks

//    void Start()
//    {
//        SpawnBrickRow();
//    }

//    public void SpawnBrickRow()
//    {
//        for (int i = 0; i < 2; i++)
//        {
//            for (int j = 0; j < columns; j++)
//            {
//                int brickValue = Random.Range(0, ballMovementScript._ballcount + 8);
//                Vector3 spawnPos = transform.position + new Vector3(j * spacing, i * -spacing, 0);

//                Debug.Log($"Spawning at row {i}, column {j}, brickValue: {brickValue}");

//                if (brickValue == 0)
//                {
//                    if (Random.value < 0.5f)
//                    {
//                        Debug.Log($"Spawning EMPTY SPACE at {spawnPos}");
//                        // Do nothing, effectively creating an empty space
//                    }
//                    else
//                    {
//                        GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
//                        if (powerUp != null)
//                        {
//                            powerUp.transform.position = spawnPos + new Vector3(0, -0.2f, 0);
//                            powerUp.SetActive(true);
//                            spawnedBricks.Add(powerUp);
//                            Debug.Log($"Spawning DIRECT POWER-UP at {powerUp.transform.position}");
//                        }
//                        else
//                        {
//                            Debug.LogWarning("Could not get a power-up from the pool!");
//                        }
//                    }
//                }
//                else
//                {
//                    GameObject brickObj = BrickPool.Instance.GetPooledBrick();
//                    if (brickObj != null)
//                    {
//                        brickObj.transform.position = spawnPos;
//                        spawnedBricks.Add(brickObj);
//                        Brick brickComponent = brickObj.GetComponent<Brick>();
//                        brickComponent.SetValue(brickValue);
//                        brickObj.SetActive(true);
//                        Debug.Log($"Spawning BRICK with value {brickValue} at {spawnPos}");

//                        if (Random.value < powerUpSpawnChance)
//                        {
//                            GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
//                            if (powerUp != null)
//                            {
//                                powerUp.transform.SetParent(brickObj.transform);
//                                powerUp.transform.localPosition = new Vector3(0, -0.2f, 0);
//                                powerUp.SetActive(true);
//                                Debug.Log($"Spawning CHILD POWER-UP on brick at {powerUp.transform.position}");
//                            }
//                            else
//                            {
//                                Debug.LogWarning("Could not get a child power-up from the pool!");
//                            }
//                        }
//                    }
//                    else
//                    {
//                        Debug.LogWarning("Could not get a brick from the pool!");
//                    }
//                }
//            }
//        }
//    }

//    public void MoveDownAndAddNewRow()
//    {
//        StartCoroutine(ShiftAndAdd());
//    }

//    IEnumerator ShiftAndAdd()
//    {
//        for (int i = 0; i < spawnedBricks.Count; i++)
//        {
//            StartCoroutine(TileDown(spawnedBricks[i].transform));
//        }
//        yield return new WaitForSeconds(0.7f);
//        NewLineSpawner();
//    }

//    private void NewLineSpawner()
//    {
//        for (int j = 0; j < columns; j++)
//        {
//            int brickValue = Random.Range(0, ballMovementScript._ballcount + 8);
//            Vector3 spawnPos = transform.position + new Vector3(j * spacing, 0, 0);

//            Debug.Log($"Spawning new line at column {j}, brickValue: {brickValue}");

//            if (brickValue == 0)
//            {
//                if (Random.value < 0.5f)
//                {
//                    Debug.Log($"Spawning EMPTY SPACE (new line) at {spawnPos}");
//                    // Do nothing for empty space
//                }
//                else
//                {
//                    GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
//                    if (powerUp != null)
//                    {
//                        powerUp.transform.position = spawnPos + new Vector3(0, -0.2f, 0);
//                        powerUp.SetActive(true);
//                        spawnedBricks.Add(powerUp);
//                        Debug.Log($"Spawning DIRECT POWER-UP (new line) at {powerUp.transform.position}");
//                    }
//                    else
//                    {
//                        Debug.LogWarning("Could not get a power-up from the pool (new line)!");
//                    }
//                }
//            }
//            else
//            {
//                GameObject brickObj = BrickPool.Instance.GetPooledBrick();
//                if (brickObj != null)
//                {
//                    brickObj.transform.position = spawnPos;
//                    spawnedBricks.Add(brickObj);
//                    Brick brickComponent = brickObj.GetComponent<Brick>();
//                    brickComponent.SetValue(brickValue);
//                    brickObj.SetActive(true);
//                    Debug.Log($"Spawning BRICK (new line) with value {brickValue} at {spawnPos}");

//                    if (Random.value < powerUpSpawnChance)
//                    {
//                        GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
//                        if (powerUp != null)
//                        {
//                            powerUp.transform.SetParent(brickObj.transform);
//                            powerUp.transform.localPosition = new Vector3(0, -0.2f, 0);
//                            powerUp.SetActive(true);
//                            Debug.Log($"Spawning CHILD POWER-UP (new line) on brick at {powerUp.transform.position}");
//                        }
//                        else
//                        {
//                            Debug.LogWarning("Could not get a child power-up from the pool (new line)!");
//                        }
//                    }
//                    else
//                    {
//                        Debug.Log($"No power-up spawned on brick with value {brickValue}");
//                    }
//                }
//                else
//                {
//                    Debug.LogWarning("Could not get a brick from the pool (new line)!");
//                }
//            }
//        }
//    }

//    IEnumerator TileDown(Transform startPos)
//    {
//        Vector3 desiredPos = startPos.position + new Vector3(0, -spacing, 0);
//        float elapsedTime = 0f;
//        float totalTime = 0.6f;
//        while (elapsedTime < totalTime)
//        {
//            startPos.position = Vector3.Lerp(startPos.position, desiredPos, elapsedTime / totalTime);
//            elapsedTime += Time.deltaTime;
//            Debug.Log(elapsedTime);
//            yield return null;
//        }
//        startPos.position = desiredPos;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickSpawner : MonoBehaviour
{
    public List<GameObject> brickPrefabs = new List<GameObject>();
    public float spacing = 0.8f;
    public List<GameObject> spawnedBricks = new List<GameObject>();
    public BallMovementScript ballMovementScript;
    public int columns = 5;
    [Range(0f, 1f)] public float powerUpSpawnChance = 0.15f;
    [Range(0f, 1f)] public float initialEmptyChance = 0.7f;
    [Range(0f, 1f)] public float minEmptyChance = 0.2f;
    public float emptyChanceDecreaseRate = 0.05f;
    [Range(0f, 1f)] public float multiplierSpawnChanceZeroValue = 0.6f;
    public float powerUpVerticalOffset = -0.1f; // Adjust this value for vertical positioning

    private int rowsSpawned = 0;

    void Start()
    {
        SpawnBrickRow();
    }

    private float GetCurrentEmptyChance()
    {
        float currentChance = initialEmptyChance - (rowsSpawned * emptyChanceDecreaseRate);
        return Mathf.Clamp(currentChance, minEmptyChance, 1f);
    }

    public void SpawnBrickRow()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float emptyRoll = Random.value;
                float currentEmptyChance = GetCurrentEmptyChance();
                int brickValue = 0; // Default to empty

                if (emptyRoll > currentEmptyChance)
                {
                    brickValue = Random.Range(1, ballMovementScript._ballcount + 8); // Ensure non-zero value
                }

                Vector3 spawnPos = transform.position + new Vector3(j * spacing, i * -spacing, 0);

                if (brickValue == 0)
                {
                    if (Random.value < (1f - multiplierSpawnChanceZeroValue)) // Chance for empty space
                    {
                        Debug.Log($"[{Time.frameCount}] Row {i}, Col {j}: Spawning EMPTY SPACE (Chance: {currentEmptyChance:F2})");
                    }
                    else
                    {
                        Debug.Log($"[{Time.frameCount}] Row {i}, Col {j}: (brickValue == 0) - Attempting to spawn DIRECT POWER-UP");
                        GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
                        if (powerUp != null)
                        {
                            powerUp.transform.position = spawnPos + new Vector3(0, powerUpVerticalOffset, 0);
                            powerUp.SetActive(true);
                            spawnedBricks.Add(powerUp);
                            Debug.Log($"[{Time.frameCount}] Row {i}, Col {j}: SUCCESS - Spawning DIRECT POWER-UP at {powerUp.transform.position}, Name: {powerUp.name}");
                        }
                        else
                        {
                            Debug.LogWarning($"[{Time.frameCount}] Row {i}, Col {j}: FAILURE - Could not get a power-up from the pool!");
                        }
                    }
                }
                else
                {
                    GameObject brickObj = BrickPool.Instance.GetPooledBrick();
                    if (brickObj != null)
                    {
                        brickObj.transform.position = spawnPos;
                        spawnedBricks.Add(brickObj);
                        Brick brickComponent = brickObj.GetComponent<Brick>();
                        brickComponent.SetValue(brickValue);
                        brickObj.SetActive(true);
                        Debug.Log($"[{Time.frameCount}] Row {i}, Col {j}: Spawning BRICK with value {brickValue} at {spawnPos}");

                        if (Random.value < powerUpSpawnChance)
                        {
                            Debug.Log($"[{Time.frameCount}] Row {i}, Col {j}: (brickValue > 0) - Attempting to spawn CHILD POWER-UP");
                            GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
                            if (powerUp != null)
                            {
                                powerUp.transform.SetParent(brickObj.transform);
                                powerUp.transform.localPosition = new Vector3(0, powerUpVerticalOffset, 0);
                                powerUp.SetActive(true);
                                Debug.Log($"[{Time.frameCount}] Row {i}, Col {j}: SUCCESS - Spawning CHILD POWER-UP (new line) on brick at {powerUp.transform.position}, Name: {powerUp.name}");
                            }
                            else
                            {
                                Debug.LogWarning($"[{Time.frameCount}] Row {i}, Col {j}: FAILURE - Could not get a child power-up from the pool!");
                            }
                        }
                        else
                        {
                            Debug.Log($"[{Time.frameCount}] Row {i}, Col {j}: No power-up spawned on brick (new line) with value {brickValue}");
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"[{Time.frameCount}] Row {i}, Col {j}: Could not get a brick from the pool!");
                    }
                }
            }
            rowsSpawned += 2; // Increment rows spawned
        }
    }
        public void MoveDownAndAddNewRow()
    {
        StartCoroutine(ShiftAndAdd());
    }

    IEnumerator ShiftAndAdd()
    {
        for (int i = 0; i < spawnedBricks.Count; i++)
        {
            StartCoroutine(TileDown(spawnedBricks[i].transform));
        }
        yield return new WaitForSeconds(0.7f);
        NewLineSpawner();
    }

    private void NewLineSpawner()
    {
        float currentEmptyChance = GetCurrentEmptyChance();
        Debug.Log($"[{Time.frameCount}] Spawning NEW ROW. Current Empty Chance: {currentEmptyChance:F2}, Rows Spawned: {rowsSpawned}");

        for (int j = 0; j < columns; j++)
        {
            float emptyRoll = Random.value;
            int brickValue = 0; // Default to empty

            if (emptyRoll > currentEmptyChance)
            {
                brickValue = Random.Range(1, ballMovementScript._ballcount + 8); // Ensure non-zero value
            }

            Vector3 spawnPos = transform.position + new Vector3(j * spacing, 0, 0);

            if (brickValue == 0)
            {
                if (Random.value < (1f - multiplierSpawnChanceZeroValue)) // Chance for empty space
                {
                    Debug.Log($"[{Time.frameCount}] New line, Col {j}: Spawning EMPTY SPACE (Chance: {currentEmptyChance:F2})");
                    // Do nothing for empty space
                }
                else
                {
                    Debug.Log($"[{Time.frameCount}] New line, Col {j}: (brickValue == 0) - Attempting to spawn DIRECT POWER-UP");
                    GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
                    if (powerUp != null)
                    {
                        powerUp.transform.position = spawnPos + new Vector3(0, powerUpVerticalOffset, 0);
                        powerUp.SetActive(true);
                        spawnedBricks.Add(powerUp);
                        Debug.Log($"[{Time.frameCount}] New line, Col {j}: SUCCESS - Spawning DIRECT POWER-UP at {powerUp.transform.position}, Name: {powerUp.name}");
                    }
                    else
                    {
                        Debug.LogWarning($"[{Time.frameCount}] New line, Col {j}: FAILURE - Could not get a power-up from the pool!");
                    }
                }
            }
            else
            {
                GameObject brickObj = BrickPool.Instance.GetPooledBrick();
                if (brickObj != null)
                {
                    brickObj.transform.position = spawnPos;
                    spawnedBricks.Add(brickObj);
                    Brick brickComponent = brickObj.GetComponent<Brick>();
                    brickComponent.SetValue(brickValue);
                    brickObj.SetActive(true);
                    Debug.Log($"[{Time.frameCount}] New line, Col {j}: Spawning BRICK (new line) with value {brickValue} at {spawnPos}");

                    if (Random.value < powerUpSpawnChance)
                    {
                        Debug.Log($"[{Time.frameCount}] New line, Col {j}: (brickValue > 0) - Attempting to spawn CHILD POWER-UP");
                        GameObject powerUp = BrickPool.Instance.GetPooledPowerUp();
                        if (powerUp != null)
                        {
                            powerUp.transform.SetParent(brickObj.transform);
                            powerUp.transform.localPosition = new Vector3(0, powerUpVerticalOffset, 0);
                            powerUp.SetActive(true);
                            Debug.Log($"[{Time.frameCount}] New line, Col {j}: SUCCESS - Spawning CHILD POWER-UP (new line) on brick at {powerUp.transform.position}, Name: {powerUp.name}");
                        }
                        else
                        {
                            Debug.LogWarning($"[{Time.frameCount}] New line, Col {j}: FAILURE - Could not get a child power-up from the pool!");
                        }
                    }
                    else
                    {
                        Debug.Log($"[{Time.frameCount}] New line, Col {j}: No power-up spawned on brick (new line) with value {brickValue}");
                    }
                }
                else
                {
                    Debug.LogWarning($"[{Time.frameCount}] New line, Col {j}: Could not get a brick from the pool (new line)!");
                }
            }
        }
        rowsSpawned++; // Increment rows spawned for new line
    }

    IEnumerator TileDown(Transform startPos)
    {
        Vector3 desiredPos = startPos.position + new Vector3(0, -spacing, 0);
        float elapsedTime = 0f;
        float totalTime = 0.6f;
        while (elapsedTime < totalTime)
        {
            startPos.position = Vector3.Lerp(startPos.position, desiredPos, elapsedTime / totalTime);
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            yield return null;
        }
        startPos.position = desiredPos;
    }
}
