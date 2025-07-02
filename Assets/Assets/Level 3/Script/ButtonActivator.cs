using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    [Header("Lift Settings")]
    public LiftOnButtonPress lift;

    [Header("Drop Object Settings")]
    public JebakanMusuh dropTarget;

    [Header("Button Visual")]
    public Transform buttonVisual;
    public float pressDepth = 0.1f;
    private Vector3 originalPosition;

    private bool hasDropped = false;

    private void Start()
    {
        if (buttonVisual != null)
            originalPosition = buttonVisual.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cowok") || other.CompareTag("cewek"))
        {
            // Aktifkan lift jika ada
            if (lift != null)
                lift.Activate();

            // Tekan tombol secara visual (selalu ditekan saat masuk)
            if (buttonVisual != null)
                buttonVisual.localPosition = originalPosition - new Vector3(0, pressDepth, 0);

            // Jalankan jebakan sekali, dan setelah itu tombol tidak naik lagi
            if (dropTarget != null && !hasDropped)
            {
                dropTarget.Drop();
                hasDropped = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("cowok") || other.CompareTag("cewek"))
        {
            // Lift boleh dinonaktifkan saat pemain keluar
            if (lift != null)
                lift.Deactivate();

            // Tapi hanya kembalikan tombol ke atas kalau drop belum dipanggil
            if (!hasDropped && buttonVisual != null)
                buttonVisual.localPosition = originalPosition;
        }
    }
}