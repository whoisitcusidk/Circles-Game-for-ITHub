using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesFactory : MonoBehaviour
{
    [Inject, Key("enemy prefab")] private GameObject _enemyPrefab;
    [Inject, Key("spawn point")] private Transform _spawnPoint;

    [SerializeField] private float _minFrequency;
    [SerializeField] private float _maxFrequency;

    [SerializeField] private float _minEnemySpeed;
    [SerializeField] private float _maxEnemySpeed;
    [SerializeField] private float _minEnemySize;
    [SerializeField] private float _maxEnemySize;
    [SerializeField] private float _minEnemyDispersion;
    [SerializeField] private float _maxEnemyDispersion;

    [SerializeField] private float _spawnPointOffset;

    private Vector3 _spawnPointPosition;

    private float _timer;
    private float _nextTimer;
    private void Start()
    {
        _nextTimer = Random.Range(_minFrequency, _maxFrequency);
        _spawnPointPosition = _spawnPoint.position;

        Create();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _nextTimer)
        {
            Create();

            _timer = 0;
            _nextTimer = Random.Range(_minFrequency, _maxFrequency);
        }
    }


    public void Create()
    {
        GameObject enemy = Instantiate(_enemyPrefab, transform);

        enemy.GetComponent<EnemyMovement>().Initialize(Random.Range(_minEnemySpeed, _maxEnemySpeed), Random.Range(_minEnemyDispersion, _maxEnemyDispersion));

        TeleportEnemy(enemy);
        SetEnemyScale(enemy);
    }

    private void TeleportEnemy(GameObject enemy)
    {
        Vector2 teleportPosition = new Vector2(
            _spawnPointPosition.x,
            _spawnPointPosition.y + Random.Range(-_spawnPointOffset, _spawnPointOffset));

        if (Physics2D.OverlapCircleAll(teleportPosition, _maxEnemySize).Length == 0)
        {
            enemy.transform.position = teleportPosition;
        }
        else
        {
            TeleportEnemy(enemy);
        }
    }

    private void SetEnemyScale(GameObject enemy)
    {
        float newScale = Random.Range(_minEnemySize, _maxEnemySize);

        enemy.transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
