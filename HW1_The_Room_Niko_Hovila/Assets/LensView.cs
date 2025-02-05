using UnityEngine;

public class LensView : MonoBehaviour
{
    public Camera lensCamera;
    public Vector3 lensOffset;

    void Update()
    {
        // Set LensCamera's position relative to Main Camera
        lensCamera.transform.position = transform.position + lensOffset;

        // Set LensCamera's rotation relative to Main Camera's forward direction
        lensCamera.transform.rotation = Quaternion.LookRotation(transform.forward, transform.up);
    }
}