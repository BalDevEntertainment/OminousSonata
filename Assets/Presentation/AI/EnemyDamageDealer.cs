using Infrastructure;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour {

    void OnTriggerEnter(Collider other) {    
        if (other.gameObject.name.Equals("Player"))
        {
            RepositoryProvider.Player().GetPlayer().OnReceiveDamage(10);
        }     
    }
}
