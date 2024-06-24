using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoleyInputs : MonoBehaviour
{
    // Private Attributes
    private bool isJumping = false;
    private bool isSpiking = false;
    private float verticalVelocity = 0f;
    private Vector3 playerStartPosition;
    private Vector3 ballStartPosition = new Vector3(-3.7f, 6.5f, -1.4f);
    public bool resetBallPosition = false;
    //Transform
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform ballTransform;
    [SerializeField]
    private Transform FContactPointTransform;
    //Movimiento    
    private float movementSpeed = 5f;
    private float jumpHeight = 5f;
    private float gravity = 9.81f;
    private float speedRotation = 450;
    //Spike
    private float spikeForce = 10f;

    // Public Methods
    public void Spike()
    {
        // Calcular la distancia entre el jugador y la pelota
        float _distance = Vector3.Distance(playerTransform.position, ballTransform.position);

        // Verificar si la distancia es menor a 2
        if (_distance < 2)
        {
            // Ajustar fuerza de remate según la distancia
            if (_distance < 1)
            {
                spikeForce = 50f;
            }
            else
            {
                spikeForce = 3f;
            }

            // Iniciar el remate si se presiona "Fire1"
            if (Input.GetButtonDown("Fire1") && !isSpiking)
            {
                isSpiking = true;
            }
        }

        // Mover la pelota al punto de contacto
        if (isSpiking)
        {
            ballTransform.position = Vector3.Lerp(ballTransform.position, FContactPointTransform.position, spikeForce * Time.deltaTime);

            // Verificar si la pelota ha llegado al punto objetivo
            if (Vector3.Distance(ballTransform.position, FContactPointTransform.position) < 0.1f)
            {
                isSpiking = false; // Detener el movimiento
            }
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

    public void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (movementSpeed == 5)
            {
        movementSpeed = 15;
            }
            else if (movementSpeed == 15)
            {
                movementSpeed = 5;
            }
        }
    }

    public void ResetBallPosition()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            resetBallPosition = true;
            ballTransform.position = ballStartPosition;
            resetBallPosition = false;
        }
    }

    private void Start()
    {
        playerStartPosition = playerTransform.position; // Guardar la posición inicial del jugador
    }

    void Update()
    {
        // Dibujar Rayos para depuración
        Debug.DrawRay(playerTransform.position, Vector3.right * Input.GetAxis("Horizontal"));
        Debug.DrawRay(playerTransform.position, Vector3.forward * Input.GetAxis("Vertical"));

        // Mover el jugador
        playerTransform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed);
        playerTransform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);

        playerTransform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * speedRotation);



        // Ejecutar métodos de salto, remate, carrera y reinicio de posición del balón
        Jump();
        Spike();
        Run();
        ResetBallPosition();
    }
}


