using UnityEngine;

public class BounceCollisionCatcher : MonoBehaviour
{
    // Private Attributes
    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private AudioSource audioSourceBounce;

    private void Start()
    {
        audioSourceBounce = GetComponent<AudioSource>();
        if (bounceSound == null)
        {
            Debug.LogError("No se ha asignado el AudioClip para el rebote en el Inspector.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("WallBounce") || collision.collider.CompareTag("Floor"))
        {
            if (audioSourceBounce != null && bounceSound != null)
                audioSourceBounce.PlayOneShot(bounceSound);
        }
    }
}

