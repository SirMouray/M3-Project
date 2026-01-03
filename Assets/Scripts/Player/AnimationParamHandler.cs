using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParamHandler : MonoBehaviour
{
    [SerializeField] private string _hSpeedName = "hSpeed";
    [SerializeField] private string _vSpeedName = "vSpeed";
    [SerializeField] private string isMovingName = "isMoving";
    [SerializeField] private string isHitName = "isHit";
    [SerializeField] private string isDeadName = "isDead";
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void SetHorizontalSpeed(float hSpeed)
    {
        _animator.SetFloat(_hSpeedName, hSpeed);
    }
    public void SetVerticalSpeed(float vSpeed)
    {
        _animator.SetFloat(_vSpeedName, vSpeed);
    }
    public void SetDirSpeed(Vector2 dirSpeed)
    {
        SetHorizontalSpeed(dirSpeed.x);
        SetVerticalSpeed(dirSpeed.y);
    }
    public void SetIsMoving(bool isMoving)
    {
        _animator.SetBool(isMovingName, isMoving);
    }

    public void SetDirAndIsMoving(Vector2 dirSpeed)
    {
        bool moving = dirSpeed != Vector2.zero;
        if (moving) SetDirSpeed(dirSpeed);
        SetIsMoving(moving);
    }

    public void SetIsHit(bool isHit)
    {
        _animator.SetBool(isHitName, isHit);
    }

    public void SetIsDead(bool isDead)
    {
        _animator.SetBool(isDeadName, isDead);
    }

}