using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightingspawner : MonoBehaviour
{
    public GameObject particleEffectPrefab; // Reference to the VFX particle effect prefab
    public Transform spawnPoint; // Point where the VFX will spawn

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
        if (particleEffectPrefab != null && spawnPoint != null)
        {
            GameObject vfxInstance = Instantiate(particleEffectPrefab, spawnPoint.position, Quaternion.identity);
            Destroy(vfxInstance, vfxInstance.GetComponent<ParticleSystem>().main.duration);
        }
        else
        {
            Debug.LogWarning("VFX prefab or spawn point not assigned!");
        }
    }
}