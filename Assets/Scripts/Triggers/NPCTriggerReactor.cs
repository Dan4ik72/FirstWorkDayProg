using UnityEngine;
using UnityEngine.Events;

public class NPCTriggerReactor : MonoBehaviour
{
    [SerializeField] private ColliderInteraction _colliderInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NPC npc))
        {
            OnNpcArrived();
        }
    }

    private void OnNpcArrived()
    {
        _colliderInteraction.ResetByDefault();
    }
}
