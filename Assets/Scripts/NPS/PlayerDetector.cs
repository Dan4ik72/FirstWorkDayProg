using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private GameEndingHandler _gameEndingHandler;

    private void OnTriggerEnter(Collider other)
    {
        TryDetectPlayer(other);
    }

    private void Start()
    {
        _gameEndingHandler = FindObjectOfType<GameEndingHandler>();
    }

    private void TryDetectPlayer(Collider enteredObject)
    {
        if (enteredObject.TryGetComponent(out Player player))
        {
            if (Physics.Raycast(transform.parent.position, (player.transform.position - transform.parent.position), out RaycastHit hit) == true)
            {
                if (hit.transform.TryGetComponent(out Player hittenPlayer) == true)
                {
                    _gameEndingHandler?.ShowSpottedPanel();
                }
            }
        }
    }
}
