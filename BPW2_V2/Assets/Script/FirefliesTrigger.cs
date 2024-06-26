using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesTrigger : MonoBehaviour
{
    public GameObject fireflies; // The Fireflies Particle System object
    private bool firefliesActivated = false; // Flag to track if the fireflies have been activated

    void Start()
    {
        if (fireflies == null)
        {
            Debug.LogError("Fireflies object is not assigned.");
        }
        else
        {
            // Ensure the fireflies are initially inactive
            fireflies.SetActive(false);
        }

        // Ensure the GameObject this script is attached to has a trigger collider
        Collider collider = GetComponent<Collider>();
        if (collider == null || !collider.isTrigger)
        {
            Debug.LogError("This GameObject needs a Collider with 'Is Trigger' enabled.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the interaction zone and the fireflies have not been activated yet
        if (other.CompareTag("Player") && !firefliesActivated)
        {
            // Activate the fireflies
            if (fireflies != null)
            {
                fireflies.SetActive(true);
                firefliesActivated = true; // Set the flag to true
            }
        }
    }

    // OnTriggerExit method is no longer needed as we do not want to turn off the fireflies
}



