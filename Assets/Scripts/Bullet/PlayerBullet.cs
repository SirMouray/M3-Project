using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnHit(Collision2D collision)
    {
        var lifeController = collision.collider.GetComponent<LifeController>();

        if (collision.collider.TryGetComponent<BaseEnemy>(out var enemy))
        {
            enemy.Hit(_damage);

            if (lifeController != null && lifeController.Hp <= 0)
            {
                enemy.Die();
            }
        }
    }
}