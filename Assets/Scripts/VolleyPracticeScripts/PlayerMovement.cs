using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Private Attributes
        private bool isJumping = false;
        private Vector3 playerStartPosition;
        private float verticalVelocity = 0f;
        private float jumpHeight = 5f;
        private float gravity = 9.81f;
        private float movementSpeed = 5f;
        private float speedRotation = 450f;

    // Start is called before the first frame update
    void Start()
    {
        playerStartPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * speedRotation);

        Jump();
    }


    public void Jump()
    {
        if (transform.position.y <= playerStartPosition.y)
        {
            isJumping = false;
            verticalVelocity = 0f;
            transform.position = new Vector3(transform.position.x, playerStartPosition.y, transform.position.z);

            // Detectar la entrada de salto
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                verticalVelocity = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
        }

        if (isJumping)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            transform.position += new Vector3(0, verticalVelocity * Time.deltaTime, 0);
        }
    }
}
