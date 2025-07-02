using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LiftSmartLoop : MonoBehaviour
{
    public float speed = 1.5f;
    public float defaultDistance = 4f;
    public float boostedDistance = 8f;

    private float currentDistance;
    private Vector3 startPos;
    private bool movingUp = true;
    private bool boosted = false;

    private Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position;
        currentDistance = defaultDistance;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void FixedUpdate()
    {
        float movement = speed * Time.fixedDeltaTime;
        Vector3 newPosition = transform.position;

        if (movingUp)
        {
            newPosition += new Vector3(0, movement, 0);
            if (newPosition.y >= startPos.y + currentDistance)
            {
                newPosition = new Vector3(transform.position.x, startPos.y + currentDistance, transform.position.z);
                movingUp = false;
            }
        }
        else
        {
            newPosition -= new Vector3(0, movement, 0);
            if (newPosition.y <= startPos.y)
            {
                newPosition = startPos;
                movingUp = true;
            }
        }

        rb.MovePosition(newPosition);
    }

    public void BoostLift()
    {
        if (!boosted)
        {
            boosted = true;
            currentDistance = boostedDistance;
            Debug.Log("Lift boosted ke jarak lebih tinggi!");
        }
    }
}
