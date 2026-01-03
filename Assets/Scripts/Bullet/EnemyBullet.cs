using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnHit(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            var lifeController = collision.collider.GetComponent<LifeController>();
            player.Hit(_damage);

            if (lifeController != null && lifeController.Hp <= 0)
            {
                player.Die();
            }
        }
    }
}