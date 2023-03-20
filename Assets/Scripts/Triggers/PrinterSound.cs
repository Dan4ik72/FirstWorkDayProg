using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private WaitForSecondsRealtime _delay = new WaitForSecondsRealtime(10f);

    private int _minDelay = 5;
    private int _maxDelay = 10;

    private void Start()
    {
        StartCoroutine(PlaySound());
    }

    private IEnumerator PlaySound()
    {
        while (true)
        {
            yield return _delay;

            _audioSource.Play();
            _delay = new WaitForSecondsRealtime(Random.Range(_minDelay, _maxDelay));

            yield return _delay;
        }
    }
}
