using UnityEngine;
using UnityEngine.UI;

public class CardFlip : MonoBehaviour
{
    public float flipDuration = 0.6f;
    public float delay = 0f;
    private bool isFlipping = false;
    private Vector3 originalScale;
    private CanvasGroup canvasGroup;

    void Start()
    {
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup != null)
            canvasGroup.alpha = 0;

        Invoke(nameof(StartFlip), delay);
    }

    void StartFlip()
    {
        if (!isFlipping)
            StartCoroutine(FlipCard());
    }

    System.Collections.IEnumerator FlipCard()
    {
        isFlipping = true;

        float time = 0f;
        float half = flipDuration / 2f;

        // Scale + fade in
        while (time < flipDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / flipDuration);

            // Rotasi Y manual
            float yRotation = Mathf.Lerp(90f, 0f, t);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);

            // Scale in
            transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);

            // Fade in
            if (canvasGroup != null)
                canvasGroup.alpha = t;

            yield return null;
        }

        // Pastikan akhir presisi
        transform.rotation = Quaternion.identity;
        transform.localScale = originalScale;
        if (canvasGroup != null)
            canvasGroup.alpha = 1;
    }
}
