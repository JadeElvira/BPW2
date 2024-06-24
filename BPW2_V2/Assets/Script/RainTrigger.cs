using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainTrigger : MonoBehaviour
{
    public AudioSource Regen;
    public GameObject RegenObject;
    public GameObject LightningObject;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player character.
        if (other.CompareTag("Player"))
        {
            Regen.Play();
            RegenObject.SetActive(true);
            RegenObject.GetComponent<ParticleSystem>().Play();
            if (LightningObject != null) // Ensure objectToEnable is not null
            {
                LightningObject.SetActive(true); // Enable the provided GameObject
            }
        }
    }


}
