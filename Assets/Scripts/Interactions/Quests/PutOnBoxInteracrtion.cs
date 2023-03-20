using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PutOnBoxInteracrtion : Interactable
{
    public event UnityAction BoxPuttedOn;

    [SerializeField] private GameObject _block;
    [SerializeField] private AudioSource _audioSource;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _startPosition = _block.transform.position;
        _startRotation = _block.transform.rotation;
    }

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        if (interactionCatcher.gameObject.GetComponentInChildren<PickUpBlockInteraction>() == null || IsAvailable == false)
            return;

        var block = interactionCatcher.gameObject.GetComponentInChildren<PickUpBlockInteraction>();

        PutOnBox(block);

        IsAvailable = false;
    }

    public override void ResetByDefault()
    {
        base.ResetByDefault();

        _block.SetActive(true);
        _block.transform.parent = null;
        _block.transform.position = _startPosition;
        _block.transform.rotation = _startRotation;
    }

    private void PutOnBox(PickUpBlockInteraction block)
    {
        _audioSource.Play();
        
        block.transform.parent = transform;
        block.gameObject.SetActive(false);

        BoxPuttedOn?.Invoke();
    }
}
