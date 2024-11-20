using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player; // �÷��̾��� Ʈ������
    private NavMeshAgent agent;
    public float moveSpeed = 3.0f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent ������Ʈ ��������
        agent.speed = moveSpeed;
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // �÷��̾��� ��ġ�� �̵�
        }
    }
}
