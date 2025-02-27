using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    Animator animator;
    private float gripTarget;
    private float triggerTarget;

    private float arrowGripTarget;
    private float arrowGripCurrent;
    private float gripCurrent;
    private float triggerCurrent;
    private String animatorGripParam = "Grip";

    private String animatorTriggerParam = "Trigger";
    private string animatorArrowGripParam = "arrowGrip";
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

        internal void SetGrip(float value)
        {
            gripTarget = value;
        }

        internal void SetTrigger(float value)
        {
            triggerTarget = value;
        }

        internal void SetArrowGrip(float value)
        {
            arrowGripTarget = value;
        }

        void AnimateHand()
        {
            if (gripCurrent != gripTarget)
            {
                gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
                animator.SetFloat(animatorGripParam, gripCurrent);
            }
            if (triggerCurrent != triggerTarget)
            {
                triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
                animator.SetFloat(animatorTriggerParam, triggerCurrent);
            }

            if (arrowGripCurrent != arrowGripTarget)
            {
                arrowGripCurrent = Mathf.MoveTowards(arrowGripCurrent, arrowGripTarget, Time.deltaTime * speed);
                animator.SetFloat(animatorArrowGripParam, arrowGripCurrent);
            }
        }
}
