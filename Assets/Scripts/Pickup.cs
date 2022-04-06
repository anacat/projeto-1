using UnityEngine;

//classe base para todos os pickups no jogo
//aqui são colocados todos os comportamentos que sejam comuns a todos os pickups
public class Pickup : MonoBehaviour
{
    protected virtual void OnPlayerTrigger(PlayerController player)
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerTrigger(other.gameObject.GetComponent<PlayerController>());
        }
    }
}
