using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEditor;

[RequireComponent(typeof(NPCMover))]
public class CuratorMoveState : MonoBehaviour
{
    [SerializeField] private List<TargetPointsHolder> _pathSequence = new List<TargetPointsHolder>();

    private CuratorDialogueState _dialogueState;
    private NPCMover _mover;

    private int _currentPathIndex = -1;
    private int _currentTargetPointIndex = 0;

    public bool IsMoving { get; private set; }

    public event UnityAction PathCompleted;

    private void Awake()
    {
        _mover = GetComponent<NPCMover>();
        _dialogueState = GetComponent<CuratorDialogueState>();

        _mover.TargetPointReached += SetNextTargetPoint;
    }

    private void OnDestroy()
    {
        _mover.TargetPointReached -= SetNextTargetPoint;
    }

    private void Start()
    {
        SetNextPath();
    }

    public void SetMoveState(bool isMoving)
    {
        IsMoving = isMoving;
    }

    public void SetNextPath()
    {
        if (_currentPathIndex + 1 >= _pathSequence.Count)
            return;

        SetMoveState(true);

        _dialogueState.enabled = false;

        _currentPathIndex++;
        _currentTargetPointIndex = 0;

        SetNextTargetPoint();
    }

    private void SetNextTargetPoint()
    {
        if (_currentTargetPointIndex >= _pathSequence[_currentPathIndex].TargetPointsTransform.Count)
        {
            OnPathCompleted();
            return;
        }

        var currentTargetPoint = _pathSequence[_currentPathIndex].TargetPointsTransform[_currentTargetPointIndex];

        _mover.SetTargetPoint(currentTargetPoint);

        _currentTargetPointIndex++;
    }

    private void OnPathCompleted()
    {
        PathCompleted?.Invoke();
        SetMoveState(false);
        _dialogueState.enabled = true;
    }
}
