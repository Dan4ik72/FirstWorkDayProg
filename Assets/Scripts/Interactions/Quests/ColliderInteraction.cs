using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ColliderInteraction : Interactable
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _boomSound;

    public UnityAction Exploded;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        _explosion.Play();
        _player.GetComponent<Recorder>().StopRecording();
        IsAvailable = false;
        StartCoroutine(PlaySound());
        Exploded?.Invoke();
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }
    
    private IEnumerator PlaySound()
    {
        _audioSource.PlayOneShot(_boomSound);
        yield return new WaitForSeconds(8f);
        _audioSource.Play();
    }
}
