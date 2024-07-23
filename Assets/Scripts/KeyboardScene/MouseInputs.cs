
using UnityEngine;

public class MouseInputs : MonoBehaviour
{

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
