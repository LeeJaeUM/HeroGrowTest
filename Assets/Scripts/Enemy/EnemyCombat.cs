using UnityEngine;

public class EnemyCombat : CharacterCombatBase
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"현재 적 총알의 공격력 : {attackPower}");
    }
}
