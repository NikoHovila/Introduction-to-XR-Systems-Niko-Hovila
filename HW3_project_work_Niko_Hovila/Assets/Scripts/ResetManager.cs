using UnityEngine;

public class ResetManager : MonoBehaviour
{
    [System.Serializable]
    public class ResettableObject
    {
        public GameObject gameObject;   // Reference to the object
        public Vector3 originalPosition; // Original position of the object
        public Quaternion originalRotation; // Original rotation of the object
    }

    public ResettableObject[] objectsToReset;

    private void Awake()
    {
        // Store original positions and rotations at the start
        foreach (var obj in objectsToReset)
        {
            if (obj.gameObject != null)
            {
                obj.originalPosition = obj.gameObject.transform.position;
                obj.originalRotation = obj.gameObject.transform.rotation;
            }
        }
    }

    public void ResetObjects()
    {
        // Reset all objects to their original state
        foreach (var obj in objectsToReset)
        {
            if (obj.gameObject != null)
            {
                obj.gameObject.SetActive(true);
                obj.gameObject.transform.position = obj.originalPosition;
                obj.gameObject.transform.rotation = obj.originalRotation;
            }
        }
    }
}
