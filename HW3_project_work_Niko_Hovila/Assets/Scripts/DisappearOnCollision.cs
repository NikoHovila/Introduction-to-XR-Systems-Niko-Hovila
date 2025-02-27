using UnityEngine;

public class DisappearOnCollision : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

private void OnCollisionEnter(Collision collision)
    {
        // Make both objects disappear when they collide
        gameObject.SetActive(false);  // Disappear this object
        collision.gameObject.SetActive(false);  // Disappear the other object
        audioManager.PlaySFX(audioManager.impact);
    }
}
