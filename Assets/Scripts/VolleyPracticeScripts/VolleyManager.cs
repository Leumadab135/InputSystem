
using UnityEngine;

public class VolleyManager : MonoBehaviour
{
    // Private Attributes
        private bool isSpiking = false;
        private Vector3 ballStartPosition = new Vector3(5.2f, 1f, -3.6f);
        private Vector3 vectorDirectionBallFloor;
        private Vector3 vectorDirectionBallMaximum;

        //Transform
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform ballTransform;
        [SerializeField] private Transform FloorContactPointTransform;
        [SerializeField] private Transform maximumAltitudPractice;
    
        //Rigidbody
        [SerializeField] private Rigidbody ballRigidbody;
    
        //Spike
        private float spikeForce;
    
        // Spike Sound
        [SerializeField] private AudioSource spikeSound;
        [SerializeField] private AudioSource harderSpikeSound;
    
    //Methods

    private void Start()
    {
        //Practice
        vectorDirectionBallMaximum = maximumAltitudPractice.position - ballTransform.position;
        vectorDirectionBallMaximum.Normalize();

        print("Welcome to my volley game!!! Press E to raise the ball and SPIKE with click.");
        print("If you want to do it again, just press R and have fun.");
    }


    void Update()
    {
        //Pushes the ball up so you can practice your spike
        if (Input.GetKeyDown(KeyCode.E))
        ballRigidbody.AddForce(vectorDirectionBallMaximum * 135);

        Spike();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.R))
        ResetBallPosition();
    }


    public void Spike()
    {
        //Ball start position
        vectorDirectionBallFloor = FloorContactPointTransform.position - ballTransform.position;
        vectorDirectionBallFloor.Normalize();

        // Distance between ball and player
        float _distance = Vector3.Distance(playerTransform.position, ballTransform.position);

        if (_distance < 2)
            spikeForce = 350f;
       
        if (_distance < 1.3f)
            spikeForce = 550f;

        if (_distance < 2f)
            {
                if (Input.GetButtonDown("Fire1") && !isSpiking)
                {
               
                    //Spike Sound 
                    if (spikeForce == 350)
                        spikeSound.Play();
                    if (spikeForce == 550)
                        harderSpikeSound.Play();

                    ballRigidbody.velocity = Vector3.zero;
                    ballRigidbody.angularVelocity = Vector3.zero;

                    ballRigidbody.AddForce(vectorDirectionBallFloor * spikeForce);

                    isSpiking = true;
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
    }
}