using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public int amount = 1;
    protected SystemManager systemManager;

    private void Start()
    {
        systemManager = GameManager.Instance.SystemManager;
        Initialize();
    }

    protected abstract void Initialize();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out PlayerManager playerManager))
        {
            ApplyEffect(playerManager);
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(PlayerManager playerManager);
}
