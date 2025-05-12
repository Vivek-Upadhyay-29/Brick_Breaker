using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallMultiplierPowerup : MonoBehaviour
{
    public int _useTimes = 2;
    [SerializeField] private  BallMovementScript ballMovementScript;
    [SerializeField] private GameObject powerUpImage;
    public TextMeshProUGUI textMesh;
    private bool isClick = false;

    void Start()
    {
        textMesh.text = _useTimes.ToString();
    }
    public void Multiplier()
    {
        if (_useTimes > 0 && !ballMovementScript.isMoving && !isClick)
        {
            
            isClick = true;
            int originalCount = ballMovementScript._ballcount;
            ballMovementScript._ballcount = originalCount +10;
            _useTimes--;
            StartCoroutine(ShowPowerup());
            textMesh.text = _useTimes.ToString();
            ballMovementScript.StartCoroutine(RestoreAfterShoot(originalCount));
        }
    }
    private IEnumerator RestoreAfterShoot(int originalCount)
    {
        yield return new WaitUntil(() => ballMovementScript.isMoving);
        yield return new WaitUntil(() => !ballMovementScript.isMoving);
        ballMovementScript._ballcount = originalCount;
        isClick = false;
    }

    IEnumerator ShowPowerup()
    {
        powerUpImage.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        powerUpImage.SetActive(false);
        yield return null;
    }
}

