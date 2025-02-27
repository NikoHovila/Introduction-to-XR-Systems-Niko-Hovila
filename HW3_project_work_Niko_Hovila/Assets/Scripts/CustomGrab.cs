/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene.
    // Define your input action in the Inspector (e.g. LeftHand/Grip and RightHand/Grip).
    
    CustomGrab otherHand = null;         // Reference to the other hand
    public List<Transform> nearObjects = new List<Transform>(); // Nearby grabbable objects
    public Transform grabbedObject = null;  // The object currently being grabbed
    public InputActionReference action;   // The grab action input

    public InputActionReference toggleDoubleRotationAction;
    bool grabbing = false;

    // For delta calculation:
    private Vector3 previousPosition;
    private Quaternion previousRotation;

    // Extra Credit: Option to double the rotation effect
    public bool doubleRotation = false;

    private void Start()
    {
        action.action.Enable();
        toggleDoubleRotationAction.action.Enable();

        // Initialize previous frame values.
        previousPosition = transform.position;
        previousRotation = transform.rotation;

        // Find the other hand among siblings.
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    void Update()
    {
        // Check if the grab action is currently pressed.
        grabbing = action.action.IsPressed();

        if (grabbing)
        {
            if(toggleDoubleRotationAction.action.WasPressedThisFrame())
            {
                doubleRotation = !doubleRotation;
            }
            // Determine which object to grab:
            // If nothing is grabbed yet, try one from nearby objects; otherwise, use the other hand's grabbed object.
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                // Calculate delta position and delta rotation for this controller.
                Vector3 deltaPos = transform.position - previousPosition;
                Quaternion deltaRot = transform.rotation * Quaternion.Inverse(previousRotation);

                // Extra credit: double the rotation effect if enabled.
                if (doubleRotation)
                {
                    // Convert deltaRot to angle-axis form.
                    float angle;
                    Vector3 axis;
                    deltaRot.ToAngleAxis(out angle, out axis);
                    // Create a new rotation that rotates twice the original angle around the same axis.
                    deltaRot = Quaternion.AngleAxis(2 * angle, axis);
                }

                // --- Apply Translation ---
                // When the controller rotates, the object (which is not necessarily at the controller’s origin)
                // should move as if it is orbiting the controller.
                // 1. Compute the object's offset from the controller:
                Vector3 relativePos = grabbedObject.position - transform.position;
                // 2. Rotate that offset by the delta rotation:
                Vector3 rotatedRelativePos = deltaRot * relativePos;
                // 3. Determine the translation caused by rotation:
                Vector3 rotationInducedTranslation = rotatedRelativePos - relativePos;
                // 4. The total translation from this hand is its delta movement plus the rotation-induced translation.
                Vector3 compositeTranslation = deltaPos + rotationInducedTranslation;
                // Apply the composite translation to the grabbed object's position.
                grabbedObject.position += compositeTranslation;

                // --- Apply Rotation ---
                // Multiply (concatenate) the delta rotation with the object's current rotation.
                grabbedObject.rotation = deltaRot * grabbedObject.rotation;
            }
        }
        else if (grabbedObject)
        {
            // If the grab button is released, release the object.
            grabbedObject = null;
        }

        // Save the current transform values to compute delta on the next frame.
        previousPosition = transform.position;
        previousRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if(t && t.tag.ToLower()=="grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if( t && t.tag.ToLower()=="grabbable")
            nearObjects.Remove(t);
    }
}*/