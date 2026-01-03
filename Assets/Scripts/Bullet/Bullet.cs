using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _lifeSpan;

    private Rigidbody2D _rb;

    protected virtual void Start()
    {
        Destroy(gameObject, _lifeSpan);
    }

    public void SetUp(Vector2 direction)
    {
        if (_rb == null)
            _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = direction * _speed;
        transform.up = direction;
    }

    protected virtual void OnHit(Collision2D collision)
    {
        // funzione virtualizzata con override nelle classi figlie
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        OnHit(collision);
        Destroy(gameObject);
    }
}