using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float damageAmount = 10f;

    [SerializeField]
    CharacterHP characterHP;

    private void Start()
    {
        characterHP = GetComponent<CharacterHP>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out PlayerManager playerManager))
        {
            // Call the DecreasePlayerHealth function on the PlayerManager
            playerManager.DecreasePlayerHealth(damageAmount);
            Debug.Log("Player hit! Health reduced by " + damageAmount);
        }
    }


}
