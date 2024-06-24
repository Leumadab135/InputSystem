using UnityEngine;

public class FollowMouseOnPlane : MonoBehaviour
{
    // Variables para almacenar el plano y la posici�n del mouse
    public Transform planeTransform;

    // Update is called once per frame
    void Update()
    {
        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Crear un rayo desde la c�mara hacia la posici�n del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Realizar un Raycast hacia el plano
            if (Physics.Raycast(ray, out hit) && hit.collider.transform == planeTransform)
            {
                // Obtener la posici�n del punto de intersecci�n en el plano
                Vector3 targetPosition = hit.point;

                // Mover el objeto vac�o a la posici�n de clic
                transform.position = targetPosition;
            }
        }
    }
}

