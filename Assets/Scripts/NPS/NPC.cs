using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private Recorder _recorder;

    public Recorder Recorder => _recorder;
}
