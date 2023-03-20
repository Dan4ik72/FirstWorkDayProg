using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ReplayData
{
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }

    public float Vertical { get; private set; }
    public float Horizontal { get; private set; }

    public ReplayData(Vector3 position, Quaternion rotation, float vertical, float horizontal)
    {
        Position = position;
        Rotation = rotation;
        Vertical = vertical;
        Horizontal = horizontal;
    }
}
