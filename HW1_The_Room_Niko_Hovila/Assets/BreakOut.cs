using UnityEngine;
using UnityEngine.InputSystem;
public class BreakOut : MonoBehaviour
{
    public InputActionReference action;
    public Vector3 roomPosition = new Vector3(0, 1, 0);
    public Vector3 externalPosition = new Vector3(0, 8, -15);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isInRoom = true;
    void Start()
    {
        action.action.Enable();
        action.action.performed += ctx =>
        {
            if (isInRoom)
            {
                transform.position = externalPosition;
            }
            else
            {
                transform.position = roomPosition;
            }

            isInRoom = !isInRoom;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
