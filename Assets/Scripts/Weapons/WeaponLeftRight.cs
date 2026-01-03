using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLeftRight : Gun
{

    public override void Fire()
    {
        float offSet = 0.5f;

        Bullet bulletLeft = Instantiate(_bulletPrefab, transform);
        bulletLeft.transform.position = (Vector2)transform.parent.position + Vector2.left * offSet;
        bulletLeft.SetUp(Vector2.left);


        Bullet bulletRight = Instantiate(_bulletPrefab, transform);
        bulletRight.transform.position = (Vector2)transform.parent.position + Vector2.right * offSet;
        bulletRight.SetUp(Vector2.right);
    }
}
