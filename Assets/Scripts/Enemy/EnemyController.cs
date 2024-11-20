using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public Transform target; // �÷��̾��� Ʈ������
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
            Debug.LogWarning("Player �±׸� ���� ������Ʈ�� ã�� �� �����ϴ�!");
        }
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent ������Ʈ ��������
        agent.speed = moveSpeed; 

    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position); // �÷��̾��� ��ġ�� �̵�
        }
    }
}
