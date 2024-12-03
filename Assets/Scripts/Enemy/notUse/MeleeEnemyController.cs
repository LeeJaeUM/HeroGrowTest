using UnityEngine;

public class MeleeEnemyController : EnemyControllerBase
{
    protected override void Move()
    {
        if (target != null)
        {
            agent.SetDestination(target.position); // 플레이어의 위치로 이동
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                animator.SetBool(isMove_Hash, true); // 이동 중일 때 애니메이션 설정
            }
            else
            {
                animator.SetBool(isMove_Hash, false); // 이동 중이 아닐 때 애니메이션 설정
                Attack();
            }
        }
        else
        {
            animator.SetBool(isMove_Hash, false); // 목표가 없을 때 애니메이션 설정
        }
    }

}
