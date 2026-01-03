using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<BaseEnemy> _enemies = new List<BaseEnemy>();
    [SerializeField] private GameObject[] _enemiesArr;
    [SerializeField] private Transform[] _spawnpos;
    [SerializeField] private float _spawnTimer;
    [SerializeField] private int _maxEnemies;

    private float _timer;

    public List<BaseEnemy> Enemies { get => _enemies; private set => _enemies = value; }

    public void AddEnemy(BaseEnemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(BaseEnemy enemy)
    {
        _enemies.Remove(enemy);
    }

    public void SpawnEnemy()
    {
        Transform spawnPoint = _spawnpos[Random.Range(0, _spawnpos.Length)];
        GameObject enemySpawned = _enemiesArr[Random.Range(0, _enemiesArr.Length)];

        Instantiate(enemySpawned, spawnPoint.position, spawnPoint.rotation);
    }

    private void Update()
    {
        if (_enemies.Count < _maxEnemies)
        {
            _timer += Time.deltaTime;

            if (_timer > _spawnTimer)
            {
                SpawnEnemy();
                _timer = 0;
            }
        }
    }
}
