using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutoTarget : Gun
{
    private EnemyManager _enemyManager;

    private void Awake()
    {
        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    private GameObject FindNearestEnemy()
    {
        GameObject nearestEnemy = null;

        float minDistance = _fireRange;

        foreach (var enemy in _enemyManager.Enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance <= minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.gameObject;
            }
        }

        return nearestEnemy;
    }

    public override void Fire()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null) return;

        Vector2 direction = (nearestEnemy.transform.position - transform.parent.position).normalized;

        float offSet = 0.5f;

        Bullet clonedBullet = Instantiate(_bulletPrefab, transform);
        clonedBullet.transform.position = (Vector2)transform.parent.position + direction * offSet;
        clonedBullet.SetUp(direction);
    }
}
