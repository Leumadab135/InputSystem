
using System.Collections;
using UnityEngine;

public class VolleyManager : MonoBehaviour
{
    //Attributes
    private Vector3 ballStartPosition = new Vector3(-1.9f, 3f, -7.46f);
    private Vector3 vectorDirectionBallMaximum;
    private Vector3 vectorDirectionBallFloor;
    private bool isSpiking = false;
    private float spikeForce;

    [Header("Transform")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Transform maximumAltitudPractice;
    [SerializeField] private Transform FloorContactPointTransform;

    [Header("Rigidbody")]
    [SerializeField] private Rigidbody ballRigidbody;

    [Header("Audio Effects")]
    [SerializeField] private AudioSource spikeSound;
    [SerializeField] private AudioSource harderSpikeSound;

    [Header("Effects")]
    public GameObject hitPrefab;
    public GameObject hitHarderPrefab;
    public GameObject resetEfectPrefab;

    //Methods
    private void Start()
    {
        print("Welcome to my volley game!!! Press F to do a reception to the setter hands");
        print("Press E (forward set) or Q (backward set) when the ball is close enough to the setter");
        print("If you want to do it again, just press R and have fun.");
    }


    void Update()
    {
        //Practice
        vectorDirectionBallMaximum = maximumAltitudPractice.position - ballTransform.position;
        vectorDirectionBallMaximum.Normalize();

        Spike();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.R))
            ResetBallPosition();
    }

    public void Spike()
    {
        vectorDirectionBallFloor = FloorContactPointTransform.position - ballTransform.position;
        vectorDirectionBallFloor.Normalize();

        // Distance between ball and player
        float _distance = Vector3.Distance(playerTransform.position, ballTransform.position);

        if (_distance < 2)
            spikeForce = 350f;

        if (_distance < 1.3f)
            spikeForce = 600f;

        if (_distance < 2f)
        {
            if (Input.GetMouseButtonDown(0) && !isSpiking)
            {
                isSpiking = true;

                ballRigidbody.velocity = Vector3.zero;
                ballRigidbody.angularVelocity = Vector3.zero;
                ballRigidbody.AddForce(vectorDirectionBallFloor * spikeForce);

                //Spike Sound and Efects 
                if (spikeForce == 350)
                {
                    spikeSound.Play();
                    Instantiate(hitPrefab, ballTransform.position, Quaternion.identity);
                }
                if (spikeForce == 600)
                {
                    harderSpikeSound.Play();
                    Instantiate(hitHarderPrefab, ballTransform.position, Quaternion.identity);
                }
            }
        }

        if (isSpiking)
            isSpiking = false;
    }

    public void ResetBallPosition()
    {
        // Reset the ball position and stop all velocities
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballTransform.position = ballStartPosition;

        Instantiate(resetEfectPrefab, ballTransform.position, Quaternion.identity);
    }
}