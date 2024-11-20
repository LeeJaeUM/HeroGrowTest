using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player; // 플레이어의 트랜스폼
    private NavMeshAgent agent;
    public float moveSpeed = 3.0f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent 컴포넌트 가져오기
        agent.speed = moveSpeed;
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // 플레이어의 위치로 이동
        }
    }
}
