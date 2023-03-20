using UnityEngine;

public class NPCTriggerAfterExplosion : MonoBehaviour
{
    [SerializeField] private NPCMover _npcMover;
    [SerializeField] private CuratorMoveState _curatorMoveState;

    public NPCMover NPCMover => _npcMover;
    public CuratorMoveState CuratorMoveState => _curatorMoveState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NPC npc))
        {
            _npcMover.enabled = false;
            _curatorMoveState.SetMoveState(false);
        }
    }
}
