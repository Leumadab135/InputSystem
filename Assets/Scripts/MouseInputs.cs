using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            print("izq");
        if (Input.GetMouseButtonUp(1))
            print("izq");
        if (Input.GetMouseButtonUp(2))
            print("izq");

        print(Input.mousePosition.x); //Esto me dice la posición del mouse en el eje x
    }
}
