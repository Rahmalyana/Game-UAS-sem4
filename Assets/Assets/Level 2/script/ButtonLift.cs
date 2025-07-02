using UnityEngine;

public class ButtonLift : MonoBehaviour
{
    public LiftSmartLoop lift;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cewek"))
        {
            lift.BoostLift();
            Debug.Log("Tombol ditekan cewek - boost lift!");
        }
    }
}
