using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
    }
}
