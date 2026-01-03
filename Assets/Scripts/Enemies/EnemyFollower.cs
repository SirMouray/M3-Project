using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollower : BaseEnemy
{
    private PlayerController _player;

    protected override void Awake()
    {
        base.Awake();
        _player = FindObjectOfType<PlayerController>();
    }

    protected override void EnemyMovement()
    {
        if (_player != null && !_isDead)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = _player.transform.position;

            Vector2 direction = targetPos - currentPos;

            Vector2 NewPos = Vector2.MoveTowards(currentPos, targetPos, _speed * Time.deltaTime);

            transform.position = NewPos;

         
            //if (direction.x != 0 || direction.y != 0)
            //{
            //    _animHandler.SetDirSpeed(direction);
            //    _animHandler.SetIsMoving(true);
            //}
            //else
            //{
            //    _animHandler.SetIsMoving(false);
            //}
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            Die();
        }
    }
}