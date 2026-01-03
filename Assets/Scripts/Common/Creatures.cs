using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creatures : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected Rigidbody2D _rb;


    protected LifeController _lifeController;
    protected PlayerController _mover2D;
    protected AnimationParamHandler _animHandler;

    protected bool _isHit;
    protected bool _isDead;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lifeController = GetComponent<LifeController>();
        _animHandler = GetComponent<AnimationParamHandler>();
    }

    public virtual void Hit(int damage)
    {
        _lifeController.TakeDamage(damage);

        if (!_isDead)
        {
            _isHit = true;
           // _animHandler.SetIsHit(true);
        }
    }

    public virtual void Die()
    {
        _isDead = true;
        // _animHandler.SetIsDead(true);
        // GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
}