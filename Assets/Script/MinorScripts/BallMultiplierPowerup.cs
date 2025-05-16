using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallMultiplierPowerup : MonoBehaviour
{
    public int _useTimes = 2;
    [SerializeField] private BallMovementScript ballMovementScript;
    [SerializeField] private GameObject powerUpImage;
    public TextMeshProUGUI textMesh;
    private bool isClick = false;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

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
            ballMovementScript._ballcount = originalCount + 10;
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
        // Get CanvasGroup component or add one if missing
        canvasGroup = powerUpImage.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = powerUpImage.AddComponent<CanvasGroup>();
        }

        rectTransform = powerUpImage.GetComponent<RectTransform>();

        canvasGroup.alpha = 1;
        powerUpImage.SetActive(true);
        rectTransform.localScale = Vector3.zero;

        float popTime = 0.2f;
        float elapsed = 0;
        while (elapsed < popTime)
        {
            elapsed += Time.deltaTime;
            float scale = Mathf.Lerp(0f, 1.2f, elapsed / popTime);
            rectTransform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

        // Blink twice (fade alpha to 0.5 then back to 1)
        for (int i = 0; i < 2; i++)
        {
            canvasGroup.alpha = 0.5f;
            yield return new WaitForSeconds(0.1f);
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(0.1f);
        }

        float fadeTime = 0.5f;
        elapsed = 0;
        while (elapsed < fadeTime)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeTime);
            yield return null;
        }

        powerUpImage.SetActive(false);
    }
}
