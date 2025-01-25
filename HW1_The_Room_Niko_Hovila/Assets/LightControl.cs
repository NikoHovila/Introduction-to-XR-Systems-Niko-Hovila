using UnityEngine;
using UnityEngine.InputSystem;

public class LightControl : MonoBehaviour
{
    public InputActionReference action;
    public Light light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isRed = false;

    void Start()
    {
        light = GetComponent<Light>();
        action.action.Enable();
        action.action.performed += ctx =>
        {
            isRed = !isRed;
            light.color = isRed ? Color.red : Color.white; // Alternate between red and white
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
