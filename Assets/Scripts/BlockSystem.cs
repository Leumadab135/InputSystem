using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystem : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private float deviation = 1.5f;

    private void Update()
    {
        FollowPlayerWithDeviation();
    }

    private void FollowPlayerWithDeviation()
    {
        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Vector3 deviationVector = playerTransform.right * deviation;
            Vector3 targetPosition = playerTransform.position + deviationVector;
            Vector3 directionToTarget = targetPosition - transform.position;
            directionToTarget.y = 0;

            if (directionToTarget != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            }
        }
    }
}



