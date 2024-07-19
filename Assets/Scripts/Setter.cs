using System;
using UnityEngine;

public class SettingScript : MonoBehaviour
{
    public GameObject ball; 
    [SerializeField] private Transform qPosition;
    [SerializeField] private Transform ePosition;
    [SerializeField] private Rigidbody ballRigidbody;
    private float SetDistance = 2f;
    private float maxArcHeight = 10f;
    private float gravity = 9.81f;

    private bool isSettingQ = false;
    private bool isSettingE = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, ball.transform.position);

        //Q SET
        if (Input.GetKey(KeyCode.Q))
        {
            if (distance <= SetDistance)
            {
                isSettingQ = true;
            }
        }
        else
        {
            isSettingQ = false;
        }
        
        //E set
        if (Input.GetKey(KeyCode.E))
        {
            if (distance <= SetDistance)
            {
                isSettingE = true;
            }
        }
        else
        {
            isSettingE = false;
        }
    }

    void FixedUpdate()
    {
        if (isSettingQ)
        {
            SetBallQ();
        }

        if (isSettingE)
        {
            SetBallE();
        }
    }

    void SetBallQ()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        
        Vector3 startPosition = ball.transform.position;
        Vector3 endPosition = qPosition.position;
        Vector3 direction = endPosition - startPosition;
        float distance = direction.magnitude;

        float heightDifference = endPosition.y - startPosition.y;
        float timeToReachSetter = Mathf.Sqrt((1 * maxArcHeight) / gravity) + Mathf.Sqrt((1 * (maxArcHeight - heightDifference)) / gravity);

        Vector3 velocity = new Vector3(direction.x / timeToReachSetter, maxArcHeight / (timeToReachSetter / 2), direction.z / timeToReachSetter);

        ballRigidbody.AddForce(velocity, ForceMode.VelocityChange);

    }

    private void SetBallE()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;

        Vector3 startPosition = ball.transform.position;
        Vector3 endPosition = ePosition.position;
        Vector3 direction = endPosition - startPosition;
        float distance = direction.magnitude;

        float heightDifference = endPosition.y - startPosition.y;
        float timeToReachSetter = Mathf.Sqrt((1 * maxArcHeight) / gravity) + Mathf.Sqrt((1 * (maxArcHeight - heightDifference)) / gravity);

        Vector3 velocity = new Vector3(direction.x / timeToReachSetter, maxArcHeight / (timeToReachSetter / 2), direction.z / timeToReachSetter);

        // Aplicar la fuerza calculada
        ballRigidbody.AddForce(velocity, ForceMode.VelocityChange);

    }
}
