using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource ambientSound1, ambientSound2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ambientSound1.enabled = false;
            ambientSound2.enabled = (true);
            ambientSound2.Play();
        }
    }
}
