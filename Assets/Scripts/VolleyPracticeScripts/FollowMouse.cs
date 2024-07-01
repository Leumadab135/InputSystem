using UnityEngine;

public class FollowMouseOnPlane : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = hit.point;
                transform.position = targetPosition;
            }
        }
    }
}

