using VContainer;
using VContainer.Unity;
using UnityEngine;
using System.Runtime.CompilerServices;

public class GameLifetimeScope : LifetimeScope
{
    [Header("Technical Objects")]
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _dynamicObjects;

    [Header("Factories Info")]
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_deathMenu).Keyed("death menu");
        builder.RegisterInstance(_dynamicObjects).Keyed("dynamic objects");

        builder.RegisterInstance(_coinPrefab).Keyed("coin prefab");
        builder.RegisterInstance(_enemyPrefab).Keyed("enemy prefab");

        builder.RegisterInstance(_spawnPoint).Keyed("spawn point");
    }
}
