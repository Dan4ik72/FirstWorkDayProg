using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{ 
    [SerializeField] private ColliderInteraction _reactor;
    [SerializeField] private AudioClip _introMusicClip;
    [SerializeField] private AudioClip _stealthMusicClip;

    private AudioSource _audioSource;
    private AudioClip _currentAudioClip;

    private float _startVolume;
    private float _transientVolume = -0.5f;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _currentAudioClip = _introMusicClip;

        _reactor.Exploded += StartChangeMusic;
    }

    private void OnDisable()
    {
        _reactor.Exploded -= StartChangeMusic;
    }

    private void Update()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        if(_audioSource.isPlaying == false)
            _audioSource.PlayOneShot(_currentAudioClip);
    }

    private void StartChangeMusic()
    {
        StartCoroutine(ChangeMusic());
    }

    private IEnumerator ChangeMusic()
    {
        _startVolume = _audioSource.volume;

        while(_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, _transientVolume, Time.deltaTime);
            yield return null;
        }

        _audioSource.Stop();
        _currentAudioClip = _stealthMusicClip;

        PlayMusic();

        while(_audioSource.volume < _startVolume)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, _startVolume, Time.deltaTime);
            yield return null;
        }
    }
}