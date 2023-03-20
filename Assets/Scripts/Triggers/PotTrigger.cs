using UnityEngine;

public class PotTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    private void OnTriggerEnter(Collider other)
    {
        int randomClip = Random.Range(0, _audioClips.Length);

        if (_audioSource.isPlaying == false)
            _audioSource.PlayOneShot(_audioClips[randomClip]);
    }
}
