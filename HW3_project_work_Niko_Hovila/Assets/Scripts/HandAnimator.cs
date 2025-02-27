/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
[RequireComponent(typeof(Animator))]
public class HandAnimator : MonoBehaviour
{   
[SerializeField] private XRInputValueReader<float> m_TriggerInput = new XRInputValueReader<float>("Trigger");
[SerializeField] private XRInputValueReader<float> m_GripInput = new XRInputValueReader<float>("Grip");
private Animator handAnimator = null;

private void Start()
{
    this.handAnimator = GetComponent<Animator>();
}

private void Update()
{
    this.handAnimator.SetFloat("Trigger", m_TriggerInput.value);
    this.handAnimator.SetFloat("Grip", m_GripInput.value);
}
}
*/