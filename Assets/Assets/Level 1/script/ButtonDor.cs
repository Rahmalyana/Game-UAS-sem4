using UnityEngine;
using System.Collections; // ← PENTING untuk IEnumerator!

public class ButtonDor : MonoBehaviour
{
    public GameObject door;
    public float moveDistance = 1.5f;
    public float moveDuration = 0.1f;

    private Vector3 originalPosition;
    private Coroutine moveCoroutine;

    private void Start()
    {
        if (door != null)
        {
            originalPosition = door.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cowok"))
        {
            if (door != null && moveCoroutine == null)
            {
                moveCoroutine = StartCoroutine(SmoothHide());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("cowok"))
        {
            if (door != null)
            {
                StopAllCoroutines();
                door.SetActive(true);
                door.transform.position = originalPosition;
                moveCoroutine = null;
            }
        }
    }

    // Fungsi Coroutine untuk animasi pintu turun
    private IEnumerator SmoothHide()
    {
        Vector3 targetPosition = door.transform.position - new Vector3(0, moveDistance, 0);
        float elapsed = 0f;
        Vector3 startPos = door.transform.position;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            door.transform.position = Vector3.Lerp(startPos, targetPosition, t);
            yield return null;
        }

        door.SetActive(false);
        door.transform.position = originalPosition;
        moveCoroutine = null;
    }
}
