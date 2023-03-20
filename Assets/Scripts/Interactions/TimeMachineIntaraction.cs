using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TimeTravelHandler))]
public class TimeMachineIntaraction : Interactable
{
    public event UnityAction TimeTraveled;

    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _teleportSound;

    private TimeTravelHandler _timeTravelHandler;

    private void Awake()
    {
        _timeTravelHandler = GetComponent<TimeTravelHandler>();
    }

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        _timeTravelHandler.OnTimeTravel();

        _effect.Stop();
        StartCoroutine(PlayTeleportSound());
        TimeTraveled?.Invoke();
    }

    public void RestartReplays()
    {
        _timeTravelHandler.RestartClonesRecordings();

        StartCoroutine(PlayTeleportSound());
        TimeTraveled?.Invoke();
    }

    public void TurnOn()
    {
        _effect.Play();
    }

    private IEnumerator PlayTeleportSound()
    {
        _audioSource.PlayOneShot(_teleportSound);

        yield return new WaitForSeconds(2f);

        _audioSource.Play();
    }
}
