using System.Collections;
using System.Collections.Generic;
using Domain.PlayerEntity;
using Infrastructure;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject RespawnPoint;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = RepositoryProvider.Enemy().GetEnemy();
        _enemy.OnPlayerWasDeath += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
       Debug.Log("ALALALAL");
    }

}
