using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy_Meele : EnemyBase
{
    public override void Attack()
    {
        Debug.Log($"meele에서 공격 작동함!!_-----------__--!");
        animController.AttackAnim();
    }

    public override bool IsAttackable()
    {
        Debug.Log($"meele에서 공격가능한지 체크 함");
        bool result = GetDistanceToPlayer() < attackDistance;
        return result;
    }

}
