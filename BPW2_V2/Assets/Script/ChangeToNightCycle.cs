using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToNightCycle : MonoBehaviour
{
    public Material newMaterial; // The material to change to
    private Renderer rend; // The renderer component of the object
    private bool isInteractable = false; // Flag to check if the object is currently interactable
    public Light directionalLight;
    public float intensity = 1.0f;
    public Color color = Color.white;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Check for player interaction
        if (isInteractable)
        {
            ChangeObjectMaterial();

            if (directionalLight == null)
            {
                // If directionalLight is not assigned, try to find it in the scene
                directionalLight = GameObject.FindObjectOfType<Light>();
            }

            if (directionalLight != null)
            {
                // Change light intensity
                directionalLight.intensity = intensity;

                // Change light color
                directionalLight.color = color;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the interaction zone
        if (other.CompareTag("Player"))
        {
            isInteractable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the interaction zone
        if (other.CompareTag("Player"))
        {
            isInteractable = false;
        }
    }
    void ChangeObjectMaterial()
    {
        // Change the material of the object
        rend.material = newMaterial;
    }
    void OnValidate()
    {
        if (directionalLight == null)
        {
            // If directionalLight is not assigned, try to find it in the scene
            directionalLight = GameObject.FindObjectOfType<Light>();
        }

        if (directionalLight != null)
        {
            // Change light intensity
            directionalLight.intensity = intensity;

            // Change light color
            directionalLight.color = color;
        }
        else
        {
            Debug.LogWarning("Directional Light not found. Please assign a Directional Light to the script.");
        }
    }
}