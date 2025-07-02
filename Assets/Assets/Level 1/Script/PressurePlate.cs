using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform woodBarrier;   // Drag balok kayu ke sini di Inspector
    public Vector3 raisedPosition;  // Posisi kayu saat naik
    public Vector3 loweredPosition; // Posisi kayu normal
    public float moveSpeed = 5f;    // Kecepatan naik-turun kayu

    //private bool playerOnPlate = false;
    private bool triggered = false;

    void Update()
    {
        // if (woodBarrier == null) return;

        // // Jika player di atas plate, kayu bergerak ke posisi raised
        // Vector3 targetPos = playerOnPlate ? raisedPosition : loweredPosition;
        // woodBarrier.position = Vector3.MoveTowards(woodBarrier.position, targetPos, moveSpeed * Time.deltaTime);
        if (woodBarrier == null) return;

        // Kalau sudah triggered, kayu bergerak ke posisi raised
        if (triggered)
        {
            woodBarrier.position = Vector3.MoveTowards(woodBarrier.position, raisedPosition, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag("Player"))
        // {
        //     playerOnPlate = true;
        // }
        if (!triggered && (other.CompareTag("cewek") || other.CompareTag("cowok")))
        {
            triggered = true; // Aktifkan trigger hanya sekali
        }
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         playerOnPlate = false;
    //     }
    // }
}
