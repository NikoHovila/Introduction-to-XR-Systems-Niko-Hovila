using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 nextPosition;
    private Vector3 originPosition;
    private HingeJoint leverHinge;

    [SerializeField]
    private float arriveThreshold = 0.1f, movementRadius = 2f, baseSpeed = 2f, slowSpeed = 0.5f, fastSpeed = 4f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originPosition = transform.position;
        nextPosition = GetNewMovementPosition();

        // Find the first available HingeJoint in the scene
        leverHinge = FindFirstObjectByType<HingeJoint>(); 
    }

    private Vector3 GetNewMovementPosition()
    {
        return originPosition + (Vector3)Random.insideUnitCircle * movementRadius;
    }

    private void FixedUpdate()
    {
        AdjustSpeedBasedOnLever();

        if (Vector3.Distance(transform.position, nextPosition) < arriveThreshold)
        {
            nextPosition = GetNewMovementPosition();
        }

        Vector3 direction = nextPosition - transform.position;
        rb.MovePosition(transform.position + direction.normalized * Time.fixedDeltaTime * baseSpeed);
    }

    private void AdjustSpeedBasedOnLever()
    {
        if (leverHinge != null)
        {
            float angle = leverHinge.angle; // Get hinge joint angle
            float minLimit = leverHinge.limits.min;
            float maxLimit = leverHinge.limits.max;

            // If the lever is near the min limit, slow down
            if (Mathf.Abs(angle - minLimit) < 5f)
            {
                baseSpeed = slowSpeed;
            }
            // If the lever is near the max limit, speed up
            else if (Mathf.Abs(angle - maxLimit) < 5f)
            {
                baseSpeed = fastSpeed;
            }
            else
            {
                baseSpeed = 3f; // Default speed
            }
        }
    }
}
