using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RestartPowerSupplyInteraction : Interactable
{
    [SerializeField] private GameObject _bulb;
    [SerializeField] private Material _greenBulbMaterial;
    [SerializeField] private Material _redBulbMaterial;

    [SerializeField] private Color _redLightColor;
    [SerializeField] private Color _greenLightColor;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioServerOn;

    private MeshRenderer _bulbMeshRenderer;
    private Light _bulbLight;

    public event UnityAction PowerSupplyRestarted;

    private void Awake()
    {
        _bulbMeshRenderer = _bulb.gameObject.GetComponent<MeshRenderer>();
        _bulbLight = _bulb.gameObject.GetComponent<Light>();
    }

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        RestartPowerSupply();
    }

    public override void ResetByDefault()
    {
        base.ResetByDefault();

        _bulbLight.color = _redLightColor;
        _bulbMeshRenderer.material = _redBulbMaterial;
    }

    private void RestartPowerSupply()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_audioServerOn);

        _bulbMeshRenderer.material = _greenBulbMaterial;
        _bulbLight.color = _greenLightColor;
        IsAvailable = false;

        PowerSupplyRestarted?.Invoke();
    }
}
