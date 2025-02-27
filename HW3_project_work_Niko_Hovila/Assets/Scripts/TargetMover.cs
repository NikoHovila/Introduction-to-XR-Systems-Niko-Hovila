using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class TargetMover : MonoBehaviour
{
    public List<Transform> potentialTarget3Objects = new List<Transform>();
    public List<Transform> potentialTarget4Objects = new List<Transform>();
    public InputActionReference moveActionTarget34;
    public Transform targetObject1;
    public Transform targetObject2;
    public float speedMultiplier = 1f; // ✅ Adjustable multiplier for speed based on distance

    private bool isMovingTarget4AlongVector = false;
    private Vector3 target1ToTarget3Direction;

    private Transform targetObject3;
    private Transform targetObject4;

    void OnEnable()
    {
        moveActionTarget34.action.Enable();

        moveActionTarget34.action.canceled += ctx =>
        {
            targetObject3 = FindClosestObject(potentialTarget3Objects, transform.position);
            targetObject4 = FindClosestObject(potentialTarget4Objects, transform.position);

            if (targetObject3 != null && targetObject4 != null && targetObject1 != null && targetObject2 != null)
            {
                target1ToTarget3Direction = (targetObject3.position - transform.position).normalized;
                isMovingTarget4AlongVector = true;
            }
        };
    }

    void OnDisable()
    {
        moveActionTarget34.action.Disable();
        moveActionTarget34.action.canceled -= ctx => isMovingTarget4AlongVector = false;
    }

    void Update()
    {
        if (isMovingTarget4AlongVector && targetObject4 != null && targetObject1 != null && targetObject2 != null)
{
    float distance = Vector3.Distance(targetObject1.position, targetObject2.position);
    float moveSpeed = distance * speedMultiplier + 1f; // ✅ Added baseline speed

    targetObject4.position += target1ToTarget3Direction * moveSpeed * Time.deltaTime;

    if (Vector3.Distance(targetObject4.position, targetObject3.position) < 0.1f)
    {
        isMovingTarget4AlongVector = false;
    }
}

    }

    private Transform FindClosestObject(List<Transform> objects, Vector3 position)
    {
        Transform closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform obj in objects)
        {
            if (obj == null) continue;
            float distance = Vector3.Distance(position, obj.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }

        return closestObject;
    }
}
