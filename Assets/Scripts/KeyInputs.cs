using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            print("La tecla se ha presionado.");
        
        if (Input.GetKey(KeyCode.Space))
            print("La tecla se est� presionando.");
        
        if (Input.GetKeyUp(KeyCode.Space))
            print("La tecla dej� de ser presionada.");
    }
}
