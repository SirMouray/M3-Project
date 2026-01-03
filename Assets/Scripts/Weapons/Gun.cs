using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Gun : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected float _fireRange;

    protected float _lastShot;

    public abstract void Fire();

    private bool CanShootNow()
    {
        return Time.time - _lastShot > _fireRate;
    }

    private void TryToShoot()
    {
        if (CanShootNow())
        {
            _lastShot = Time.time;
            Fire();
        }
    }

    private void Update()
    {
        TryToShoot();
    }
}