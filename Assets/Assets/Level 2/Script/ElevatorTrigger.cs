using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public Transform elevator;          // Balok yang akan bergerak
    public Transform targetPos;         // Posisi tujuan naik
    public float speed = 2f;

    private bool activated = false;
    public Transform startPos;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Trigger aktif kalau player menginjak
        {
            activated = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        activated = false;
    }
}

    void Update()
    {
        if (activated)
        {
            elevator.position = Vector2.MoveTowards(elevator.position, targetPos.position, speed * Time.deltaTime);
        }
        else
        {
            elevator.position = Vector2.MoveTowards(elevator.position, startPos.position, speed * Time.deltaTime);
        }
    }
}
