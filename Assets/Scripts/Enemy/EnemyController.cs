using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public Transform target; // 플레이어의 트랜스폼
    private NavMeshAgent agent;
    public float moveSpeed = 3.0f;


    void Start()
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
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent 컴포넌트 가져오기
        agent.speed = moveSpeed; 

    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position); // 플레이어의 위치로 이동
        }
    }
}
