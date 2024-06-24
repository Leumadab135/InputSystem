using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{

    //Public Attributes
    public Transform cubeTransform;
    public float speed;

    void Update()
    {    
        //DrawRys
        Debug.DrawRay(cubeTransform.transform.position, Vector3.right * Input.GetAxis("Horizontal"));
        Debug.DrawRay(cubeTransform.transform.position, Vector3.forward * Input.GetAxis("Vertical"));
       
        //Translate
        cubeTransform.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
       
        cubeTransform.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);

        //Fire y Mouse Wheel
        if (Input.GetButtonDown("Fire1")) //Devuelve un bool, me di cuenta que es con el mouse
            print("FIRE!!!");

        print("Mouse wheel: " + Input.GetAxis("Mouse ScrollWheel")); //Esto muestra un seguimiento de la rueda del mouse.
        
    }
}
