using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] private Animator dummyAnimator;  // Reference to the Animator component for dummy animations
    private VRDummyTimer timerScript;                // Reference to the VRDummyTimer script

    private void Start()
    {
        // Find the VRDummyTimer script in the scene
        timerScript = FindObjectOfType<VRDummyTimer>();

        // Optional: Check if the timerScript is found
        if (timerScript == null)
        {
            Debug.LogWarning("VRDummyTimer script not found in the scene.");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Check if the object colliding is a bullet or weapon
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Weapon"))
        {
            // Trigger the death animation
            dummyAnimator.SetTrigger("Death");

            // Notify the timer script that a dummy was killed
            if (timerScript != null)
            {
                timerScript.DummyKilled();  // Call the DummyKilled function in VRDummyTimer
            }

            // Optionally, destroy the dummy after the death animation completes
            Destroy(gameObject, 2f);  // Adjust the delay based on your animation length
        }
    }

    public void ActivateDummy()
    {
        // Trigger the activation animation
        dummyAnimator.SetTrigger("Activate");
    }
}
