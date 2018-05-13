using Infrastructure;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour {
   
    private static string PLAYER_TAG;
    static EnemyDamageDealer()
    {
        PLAYER_TAG = "Player";
    }

    void OnTriggerEnter(Collider other) {    
        if (other.gameObject.name.Equals(PLAYER_TAG))
        {
            RepositoryProvider.Player().GetPlayer().OnPlayerDeath();
            RepositoryProvider.Enemy().GetEnemy().OnKillPlayer();
        }
        
    }
}
