using System.Collections;
using System.Collections.Generic;
using Domain.PlayerEntity;
using Infrastructure;
using UnityEngine;

public class EnemyContext : MonoBehaviour
{

	private Enemy _enemy;
	private EnemyDamageDealer damageDealer;
	
	private void Awake()
	{
		damageDealer = GetComponent<EnemyDamageDealer>();
		_enemy = new Enemy(RepositoryProvider.Enemy());
	}
}
