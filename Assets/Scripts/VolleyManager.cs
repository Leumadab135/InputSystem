
using UnityEngine;

public class VolleyManager : MonoBehaviour
{
    // Private Attributes
    private bool isJumping = false;
    private bool isSpiking = false;
    private float verticalVelocity = 0f;
    private Vector3 playerStartPosition;
    private Vector3 ballStartPosition = new Vector3(-3.7f, 0.5f, -1.4f);
    private Vector3 vectorDirectionBallFloor;
    private Vector3 vectorDirectionBallMaximum;
    //Transform
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Transform FloorContactPointTransform;
    [SerializeField] private Transform maximumAltitudPractice;
    //Rigidbody
    [SerializeField] private Rigidbody ballRigidbody;
    //Movimiento    
    private float movementSpeed = 5f;
    private float jumpHeight = 5f;
    private float gravity = 9.81f;
    private float speedRotation = 450f;
    //Spike
    private float spikeForce;
    //Sound
    [SerializeField] private AudioSource spikeSound;
    [SerializeField] private AudioSource harderSpikeSound;
    // Public Methods
    public void Spike()
    {
        //Ball start position
        vectorDirectionBallFloor = FloorContactPointTransform.position - ballTransform.position;
        vectorDirectionBallFloor.Normalize();

        // Calcular la distancia entre el jugador y la pelota
        float _distance = Vector3.Distance(playerTransform.position, ballTransform.position);

        if (_distance < 2)
            spikeForce = 350f;
        if (_distance < 1.5f)
            spikeForce = 550f;

        // Verificar si la distancia es menor a 2 para rematar
        if (_distance < 2f)
            {
                if (Input.GetButtonDown("Fire1") && !isSpiking)
                {
               
                    //Spike Sound 
                    if (spikeForce == 350)
                        spikeSound.Play();
                    if (spikeForce == 550)
                        harderSpikeSound.Play();

                    // Anular todas las velocidades de la pelota
                    ballRigidbody.velocity = Vector3.zero;
                    ballRigidbody.angularVelocity = Vector3.zero;

                    // Mover la pelota al punto de contacto
                    ballRigidbody.AddForce(vectorDirectionBallFloor * spikeForce);

                    isSpiking = true;
                }
            }

        // Resetear el estado del remate después de aplicar la fuerza
        if (isSpiking)
        {
            isSpiking = false;
        }
    }


    public void Jump()
    {
        if (playerTransform.position.y <= playerStartPosition.y)
        {
            isJumping = false;
            verticalVelocity = 0f;
            playerTransform.position = new Vector3(playerTransform.position.x, playerStartPosition.y, playerTransform.position.z);

            // Detectar la entrada de salto
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                verticalVelocity = Mathf.Sqrt(2 * jumpHeight * gravity); // Calcular la velocidad inicial del salto
            }
        }

        // Aplicar la gravedad y la velocidad del salto
        if (isJumping)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            playerTransform.position += new Vector3(0, verticalVelocity * Time.deltaTime, 0);
        }
    }
    public void ResetBallPosition()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ballTransform.position = ballStartPosition;
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void Start()
    {
        playerStartPosition = playerTransform.position; // Guardar la posición inicial del jugador
        ballStartPosition = ballTransform.position;

        //Practice
        vectorDirectionBallMaximum = maximumAltitudPractice.position - ballTransform.position;
        vectorDirectionBallMaximum.Normalize();

        print("Welcome to my volley game!!! Press E to raise the ball and SPIKE with click.");
        print("If you want to do it again, just press R and have fun." );
    }

    void Update()
    {
        // Mover el jugador
        playerTransform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed);
        playerTransform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);

        playerTransform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * speedRotation);

        //Pushes the ball up so you can practice your spike
        if(Input.GetKeyDown(KeyCode.E))
        {
            ballRigidbody.AddForce(vectorDirectionBallMaximum * 130);
        }

        // Ejecutar métodos de salto, remate, carrera y reinicio de posición del balón
        Jump();
        Spike();
        ResetBallPosition();
        print(spikeForce);
    }
}


