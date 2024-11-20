using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //EnemyManager enemy = other.TryGetComponent<>

        //if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        //{
        //    EnemyCombat enemy = other.GetComponent<EnemyCombat>();
        //    if (enemy != null)
        //    {
        //        TakeDamage(enemy.AttackPower);
        //    }
        //    else
        //    {
        //        Debug.Log("CharacterCombatBase가 존재하지 않는 적 오브젝트에 닿음!!");
        //    }
        //}
    }
}
