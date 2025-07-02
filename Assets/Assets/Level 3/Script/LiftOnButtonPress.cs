using UnityEngine;

public class LiftOnButtonPress : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private bool isActivated = false;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (!isActivated) return; // hanya jalan kalau sudah aktif

        float movement = speed * Time.deltaTime;

        if (movingUp)
        {
            transform.position += new Vector3(0, movement, 0);
            if (transform.position.y >= startPos.y + moveDistance)
                movingUp = false;
        }
        else
        {
            transform.position -= new Vector3(0, movement, 0);
            if (transform.position.y <= startPos.y)
            {
                transform.position = startPos;
                movingUp = true;
            }
        }
    }

    public void Activate() => isActivated = true;

    public void Deactivate() => isActivated = false;
}
