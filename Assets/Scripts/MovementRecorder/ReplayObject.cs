using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ReplayObject : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Rigidbody _rigidbody;
    private Vector3 _maxVelocity = new Vector3(2f, 2f, 2f);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetDataForFrame(ReplayData data)
    {   
        _animator.SetBool("IsMoving", transform.position != data.Position);

        _rigidbody.MovePosition(data.Position);
        _rigidbody.MoveRotation(data.Rotation);

        LimitVelocity();
    }

    private void LimitVelocity()
    {
        if (_rigidbody.velocity.magnitude > _maxVelocity.magnitude)
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxVelocity.magnitude);
    }
}
