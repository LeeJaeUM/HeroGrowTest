using UnityEngine;

public class EnemyCombat : CharacterCombatBase
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"���� �� �Ѿ��� ���ݷ� : {attackPower}");
    }
}
