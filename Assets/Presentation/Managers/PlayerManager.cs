
using Domain.PlayerEntity;
using Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject RespawnPoint;
    private Player _getPlayer;
    //Sacar luegoesta variable
    public bool RestartScene;

    private void Start()
    {
        _getPlayer = RepositoryProvider.Player().GetPlayer();
        _getPlayer.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        Debug.Log("Muerto esta");
        GameObject.FindGameObjectWithTag("Player").transform.position = RespawnPoint.transform.position;
        if (RestartScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
        }
    }

}
