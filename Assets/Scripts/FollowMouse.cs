using UnityEngine;

public class FollowMouseOnPlane : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Crear un rayo desde la cámara hacia la posición del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Realizar un Raycast hacia el plano
            if (Physics.Raycast(ray, out hit))
            {
                // Obtener la posición del punto de intersección en el plano
                Vector3 targetPosition = hit.point;

                // Mover el objeto vacío a la posición de clic
                transform.position = targetPosition;
            }
        }
    }
}

