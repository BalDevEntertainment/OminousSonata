
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour {

    void OnTriggerEnter(Collider other) {    
        if (other.gameObject.name.Equals("Player"))
        {
            Debug.Log("DAÑO PLAYER");    
        }
             
    }
}
