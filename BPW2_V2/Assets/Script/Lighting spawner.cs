using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Lightingspawner : MonoBehaviour
{
    public VisualEffect lightningEffect; // Reference to the VFX particle effect prefab
    public Transform spawnPoint; // Point where the VFX will spawn
    [SerializeField] private AudioSource lightningSound;
    [SerializeField] private float soundDelay;

    private void Awake()
    {
        lightningEffect.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the entering collider is tagged as "Player"
        {
            SpawnParticleEffect();
            Debug.Log("Particle spawned");
        }
    }

    private void SpawnParticleEffect()
    {
        StartCoroutine(LightningCoRoutine());
    }

    private IEnumerator LightningCoRoutine()
    {
        while (lightningEffect.enabled == true)
        {
            lightningEffect.Play();
            Debug.Log("play effect");

            yield return new WaitForSeconds(soundDelay);

            while(lightningEffect.enabled == true)
            {
                lightningSound.Play();
                Debug.Log("play sound");
                yield return new WaitForSeconds(soundDelay);
            }
        }

    }

}