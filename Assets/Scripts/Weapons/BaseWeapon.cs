using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : Gun
{
    private PlayerController _playerController;

    protected void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }
    public override void Fire()
    {
        float offSet = 0.5f;

        Bullet bullet = Instantiate(_bulletPrefab, transform);
        bullet.transform.position = 
            (Vector2)transform.parent.position + 
            _playerController.LastNonZeroDir * offSet;
        bullet.SetUp(_playerController.LastNonZeroDir);
    }
}