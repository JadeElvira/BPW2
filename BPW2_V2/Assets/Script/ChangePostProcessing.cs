using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class PostProcessingTrigger : MonoBehaviour
{
    public Volume volume1; // The first volume
    public Volume volume2; // The second volume
    public float blendDuration = 1.0f; // Duration of the blend

    private Coroutine blendCoroutine;

    void Start()
    {
        if (volume1 == null || volume2 == null)
        {
            Debug.LogError("Volumes are not assigned.");
            return;
        }

        // Ensure volume2 is initially disabled
        volume2.weight = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (blendCoroutine != null)
            {
                StopCoroutine(blendCoroutine);
            }
            blendCoroutine = StartCoroutine(BlendVolumes(volume1, volume2, blendDuration));
        }
    }

    private IEnumerator BlendVolumes(Volume from, Volume to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            float t = time / duration;
            from.weight = Mathf.Lerp(1f, 0f, t);
            to.weight = Mathf.Lerp(0f, 1f, t);
            time += Time.deltaTime;
            yield return null;
        }
        from.weight = 0f;
        to.weight = 1f;
    }
}

