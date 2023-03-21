using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExplosionHandler : MonoBehaviour
{
    [SerializeField] private ColliderInteraction _colliderInteraction;
    [SerializeField] private TimeMachineIntaraction _timeMachine;
    [SerializeField] private Transform _timeMachineBarrier;
    [SerializeField] private NPCTriggerAfterExplosion _npcTriggerAfterExplosion;
    [SerializeField] private Player _player;

    private Vector3 _disabledTimeMachineRotation = new Vector3(84.23f, 184.187f, 0f);
    private Quaternion _enabledTimeMachineBarierRotation;
    private Vector3 _enabledTimeMachineBarrierPosition;

    private void Awake()
    {
        _enabledTimeMachineBarierRotation = _timeMachineBarrier.transform.rotation;
        _enabledTimeMachineBarrierPosition = _timeMachineBarrier.transform.position;
    }

    private void OnEnable()
    {
        _colliderInteraction.Exploded += OnExplosion;
        _timeMachine.TimeTraveled += OnRestarted;
    }

    private void OnDisable()
    {
        _colliderInteraction.Exploded -= OnExplosion;
        _timeMachine.TimeTraveled -= OnRestarted;
    }

    public void OnRestarted()
    {
        _colliderInteraction.StopSound();
        ResetTimeMachineBarier();
    }

    public void ResetTimeMachineBarier()
    {
        _timeMachineBarrier.GetComponent<MeshCollider>().enabled = true;
        _timeMachineBarrier.transform.position = _enabledTimeMachineBarrierPosition;
        _timeMachineBarrier.transform.rotation = _enabledTimeMachineBarierRotation;
    }

    private void OnExplosion()
    {
        DisableTimeMachineBarier();
        _npcTriggerAfterExplosion.NPCMover.enabled = true;

        Destroy(_npcTriggerAfterExplosion);

        _player.Radar.DeletePointersAndClearTargets();
        _timeMachine.TurnOn();
    }

    private void DisableTimeMachineBarier()
    {
        _timeMachineBarrier.GetComponent<MeshCollider>().enabled = false;
        _timeMachineBarrier.rotation = Quaternion.Euler(_disabledTimeMachineRotation);
    }

}
