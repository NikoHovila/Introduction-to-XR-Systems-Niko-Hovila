using UnityEngine;
using UnityEngine.InputSystem;

public class BoneFollower : MonoBehaviour
{
    public Transform boneToFollow;
    public Transform targetObject1;
    public Transform targetObject2;
    public InputActionReference moveAction;
    public float moveSpeed = 5f;

    private bool isFollowingTarget1 = false;
    private bool isMovingToTarget2 = false;

    private Vector3 targetPosition;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnEnable()
    {
        moveAction.action.Enable();

        moveAction.action.performed += ctx =>
        {
            isFollowingTarget1 = true;
            audioManager.PlaySFX(audioManager.pull);
        };

        moveAction.action.canceled += ctx =>
        {
            if (isFollowingTarget1)
            {
                isFollowingTarget1 = false;
                isMovingToTarget2 = true;
                targetPosition = targetObject2.position;
                audioManager.PlaySFX(audioManager.shoot);
            }
        };
    }

    void OnDisable()
    {
        moveAction.action.Disable();
        moveAction.action.performed -= ctx => isFollowingTarget1 = true;
        moveAction.action.canceled -= ctx => isFollowingTarget1 = false;
    }

    void Update()
    {
        if (isFollowingTarget1 && targetObject1 != null)
        {
            transform.position = targetObject1.position;
            if (boneToFollow != null) boneToFollow.position = targetObject1.position;
        }

        if (isMovingToTarget2 && targetObject2 != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (boneToFollow != null) boneToFollow.position = Vector3.MoveTowards(boneToFollow.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition) isMovingToTarget2 = false;
        }
    }
}
