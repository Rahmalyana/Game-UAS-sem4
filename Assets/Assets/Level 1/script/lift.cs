using UnityEngine;

public class LiftLoopUpDown : MonoBehaviour
{
    public float speed = 2f;                // Kecepatan lift
    public float moveDistance = 3f;         // Jarak maksimum ke atas dari posisi awal
    private Vector3 startPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;

        if (movingUp)
        {
            transform.position += new Vector3(0, movement, 0);
            if (transform.position.y >= startPos.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position -= new Vector3(0, movement, 0);
            if (transform.position.y <= startPos.y)
            {
                transform.position = startPos; // pastikan presisi
                movingUp = true;
            }
        }
    }
}
