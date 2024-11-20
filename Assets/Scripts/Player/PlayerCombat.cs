using UnityEngine;

public class PlayerCombat : CharacterCombatBase
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
            case "EnemyBullet":
                EnemyCombat enemy = other.GetComponent<EnemyCombat>();
                if (enemy != null)
                {
                    TakeDamage(enemy.AttackPower);
                }
                else
                {
                    Debug.Log("CharacterCombatBase가 존재하지 않는 적 오브젝트에 닿음!!");
                }
                break;

            case "Heart":
                Debug.Log("Heart에 닿았습니다.");
                Heal(10);  // 하트 아이템을 줬을 때 체력 회복
                break;

            case "Coin":
                Debug.Log("Coin에 닿았습니다.");
                //AddCoin(1);  // 코인을 1개 추가
                break;

            default:
                Debug.Log($" {other.tag} : 알 수 없는 태그입니다.");
                break;
        }
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
