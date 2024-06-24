using System.Collections;
using UnityEngine;

public class ChangeToNightCycle2 : MonoBehaviour
{
    public Material newMaterial; // The material to change to
    private Renderer rend; // The renderer component of the object
    private bool isInteractable = false; // Flag to check if the object is currently interactable
    public Light directionalLight;
    public float intensity = 1.0f;
    public Color color = Color.white;
    public float transitionDuration = 2.0f; // Duration of the transition

    private Material originalMaterial; // To store the original material
    private float originalIntensity;
    private Color originalColor;

    private Coroutine transitionCoroutine;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;

        if (directionalLight != null)
        {
            originalIntensity = directionalLight.intensity;
            originalColor = directionalLight.color;
        }
    }

    void Update()
    {
        // Check for player interaction
        if (isInteractable && transitionCoroutine == null)
        {
            if (directionalLight == null)
            {
                // If directionalLight is not assigned, try to find it in the scene
                directionalLight = GameObject.FindObjectOfType<Light>();
            }

            if (directionalLight != null)
            {
                // Start transition coroutine
                transitionCoroutine = StartCoroutine(TransitionToNightCycle());
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
            if (transitionCoroutine != null)
            {
                StopCoroutine(transitionCoroutine);
                transitionCoroutine = StartCoroutine(TransitionToDayCycle());
            }
        }
    }

    void ChangeObjectMaterial(Material material)
    {
        // Change the material of the object
        rend.material = material;
    }

    IEnumerator TransitionToNightCycle()
    {
        float elapsedTime = 0f;

        Material startMaterial = rend.material;
        float startIntensity = directionalLight.intensity;
        Color startColor = directionalLight.color;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;

            rend.material.Lerp(startMaterial, newMaterial, t);
            directionalLight.intensity = Mathf.Lerp(startIntensity, intensity, t);
            directionalLight.color = Color.Lerp(startColor, color, t);

            yield return null;
        }

        // Ensure final values are set
        ChangeObjectMaterial(newMaterial);
        directionalLight.intensity = intensity;
        directionalLight.color = color;

        transitionCoroutine = null;
    }

    IEnumerator TransitionToDayCycle()
    {
        float elapsedTime = 0f;

        Material startMaterial = rend.material;
        float startIntensity = directionalLight.intensity;
        Color startColor = directionalLight.color;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;

            rend.material.Lerp(startMaterial, originalMaterial, t);
            directionalLight.intensity = Mathf.Lerp(startIntensity, originalIntensity, t);
            directionalLight.color = Color.Lerp(startColor, originalColor, t);

            yield return null;
        }

        // Ensure final values are set
        ChangeObjectMaterial(originalMaterial);
        directionalLight.intensity = originalIntensity;
        directionalLight.color = originalColor;

        transitionCoroutine = null;
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
