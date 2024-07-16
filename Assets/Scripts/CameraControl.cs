using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Attributes
    private float speedRotation = 300;
    private float xRotation = 0f;
    private float minY = -40f;
    private float maxY = 40f;
    private float verticalOffsetAmount =3f;
    private Vector3 initialCameraPosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        initialCameraPosition = transform.localPosition;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * speedRotation * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        float yOffset = Mathf.Lerp(0f, verticalOffsetAmount, Mathf.InverseLerp(minY, maxY, xRotation));

        transform.localPosition = new Vector3(initialCameraPosition.x, initialCameraPosition.y + yOffset, initialCameraPosition.z);
    }
}
