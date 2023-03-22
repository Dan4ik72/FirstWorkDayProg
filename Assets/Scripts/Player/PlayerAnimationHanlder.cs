using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHanlder : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _isMovingParameterHash = Animator.StringToHash("IsMoving");

    public void SetPlayingWalkAnimation(bool isMoving)
    {
        _animator.SetBool(_isMovingParameterHash, isMoving);
    }
}

