using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesTrigger : MonoBehaviour
{
    public GameObject fireflies; // The Fireflies Particle System object

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
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the interaction zone
        if (other.CompareTag("Player"))
        {
            // Activate the fireflies
            if (fireflies != null)
            {
                fireflies.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the interaction zone
        if (other.CompareTag("Player"))
        {
            // Deactivate the fireflies
            if (fireflies != null)
            {
                fireflies.SetActive(false);
            }
        }
    }
}


