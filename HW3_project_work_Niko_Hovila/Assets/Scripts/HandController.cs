using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    public InputActionReference gripAction;
    public InputActionReference triggerAction;
    public InputActionReference arrowGripAction;

    public Animator handAnimator;

    private const string GripParam = "Grip";
    private const string TriggerParam = "Trigger";

    private const string ArrowGripParam = "arrowGrip";

void OnEnable()
{
    gripAction.action.Enable();
    triggerAction.action.Enable();
    arrowGripAction.action.Enable();

    gripAction.action.performed += OnGripPerformed;
    gripAction.action.canceled += OnGripPerformed; 

    triggerAction.action.performed += OnTriggerPerformed;
    triggerAction.action.canceled += OnTriggerPerformed; 

    arrowGripAction.action.performed += OnArrowGripPerformed;
    arrowGripAction.action.canceled += OnArrowGripPerformed;
}

    void OnDisable()
    {
        gripAction.action.performed -= OnGripPerformed;
        triggerAction.action.performed -= OnTriggerPerformed;
        arrowGripAction.action.performed -= OnArrowGripPerformed;

        gripAction.action.Disable();
        triggerAction.action.Disable();
        arrowGripAction.action.Disable();
    }

private void OnGripPerformed(InputAction.CallbackContext ctx)
{
    float gripValue = ctx.ReadValue<float>();
    handAnimator.SetFloat(GripParam, gripValue);
}

private void OnTriggerPerformed(InputAction.CallbackContext ctx)
{
    float triggerValue = ctx.ReadValue<float>();
    handAnimator.SetFloat(TriggerParam, triggerValue);
}

private void OnArrowGripPerformed(InputAction.CallbackContext ctx)
{
    float arrowGripValue = ctx.ReadValue<float>();
    handAnimator.SetFloat(ArrowGripParam, arrowGripValue);
}
}