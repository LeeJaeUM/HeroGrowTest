using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;  // Bullet 프리팹
    public Transform target;  // 플레이어 Transform

    protected virtual void Start()
    {
        FindPlayer();
    }

    // 총알을 생성하는 함수
    public virtual void SpawnObject()
    {
        if (objectPrefab != null)
        {
            Instantiate(objectPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Spawn Point is not assigned.");
        }
    }

    public void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player 태그를 가진 오브젝트를 찾을 수 없습니다!");
        }
    }
}
