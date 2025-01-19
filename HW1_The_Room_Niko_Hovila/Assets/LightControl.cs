using UnityEngine;
using UnityEngine.InputSystem;

public class LightControl : MonoBehaviour
{
    public InputActionReference action;
    public Light light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        action.action.Enable();
        action.action.performed += ctx =>
        {
            light.enabled = !light.enabled;
            light.color = Color.red;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
