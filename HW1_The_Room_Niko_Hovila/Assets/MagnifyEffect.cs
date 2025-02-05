using UnityEngine;

public class MagnifyEffect : MonoBehaviour
{
    public Camera vrCamera;       // The main VR headset camera
    public Camera magnifyCamera;  // The magnifying glass camera
    public Material magnifyMaterial;
    public float minMagnify = 1.0f;
    public float maxMagnify = 1.5f;

    public Transform lensCenterTransform;

    void Update()
    {
        if (vrCamera == null || magnifyCamera == null || magnifyMaterial == null)
            return;
            
        // Use the lensCenterTransform's position for calculations.
        Vector3 lensCenterPos = lensCenterTransform.position;

        // Calculate the target by reflecting the VR camera's position about the lens center.
        // This effectively gives you the "opposite" position.
        Vector3 target = 2 * lensCenterPos - vrCamera.transform.position;

        // Make the magnify camera look at this target.
        // Use the magnifying lens's up vector (transform.up) as the reference up direction.
        magnifyCamera.transform.LookAt(target, transform.up);

        // Get the vector from the lens to the VR camera.
        Vector3 toCamera = (vrCamera.transform.position - transform.position).normalized;

        // Determine if the VR camera is behind the lens.
        // Only apply magnification if the object is behind the lens.
        float dot = Vector3.Dot(transform.forward, toCamera);
        if (dot < 0) // Only objects in the "backward" direction get magnified
        {
            float angle = Mathf.Clamp01(1 - dot);
            float magnifyStrength = Mathf.Lerp(minMagnify, maxMagnify, angle);
            magnifyMaterial.SetFloat("_MagnifyStrength", magnifyStrength);
        }
        else
        {
            // If the VR camera is in front of the lens, disable magnification.
            magnifyMaterial.SetFloat("_MagnifyStrength", 1.0f);
        }
    }
}