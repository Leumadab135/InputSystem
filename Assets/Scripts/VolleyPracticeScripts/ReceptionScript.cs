using UnityEngine;

public class ReceptionScript : MonoBehaviour
{
    public GameObject ball;
    [SerializeField] private Transform setter;
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private AudioSource receptionSound;
    
    private float receptionDistance = 1.5f;
    private float maxArcHeight = 10f;
    private float gravity = 9.81f;

    private bool isReceiving = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (Vector3.Distance(transform.position, ball.transform.position) <= receptionDistance)
            {
                isReceiving = true;
            }
        }
        else
        {
            isReceiving = false;
        }
    }

    void FixedUpdate()
    {
        if (isReceiving)
        {
            ReceiveBall();
        }
    }

    void ReceiveBall()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        
        Vector3 startPosition = ball.transform.position;
        Vector3 endPosition = setter.position;
        Vector3 direction = endPosition - startPosition;
        float distance = direction.magnitude;

        float heightDifference = endPosition.y - startPosition.y;
        float timeToReachSetter = Mathf.Sqrt((1 * maxArcHeight) / gravity) + Mathf.Sqrt((1 * (maxArcHeight - heightDifference)) / gravity);

        Vector3 velocity = new Vector3(direction.x / timeToReachSetter, maxArcHeight / (timeToReachSetter / 2), direction.z / timeToReachSetter);

        ballRigidbody.AddForce(velocity, ForceMode.VelocityChange);
        receptionSound.Play();
    }
}


