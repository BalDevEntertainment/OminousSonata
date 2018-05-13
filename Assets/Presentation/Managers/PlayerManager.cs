using System.Collections;
using System.Collections.Generic;
using Domain.PlayerEntity;
using Infrastructure;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject RespawnPoint;
    private Player _getPlayer;

    private void Start()
    {
        _getPlayer = RepositoryProvider.Player().GetPlayer();
        _getPlayer.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        Debug.Log("Muerto esta");
        GameObject.FindGameObjectWithTag("Player").transform.position = RespawnPoint.transform.position;
    }

}
