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
                    Debug.Log("CharacterCombatBase�� �������� �ʴ� �� ������Ʈ�� ����!!");
                }
                break;

            case "Heart":
                Debug.Log("Heart�� ��ҽ��ϴ�.");
                Heal(10);  // ��Ʈ �������� ���� �� ü�� ȸ��
                break;

            case "Coin":
                Debug.Log("Coin�� ��ҽ��ϴ�.");
                //AddCoin(1);  // ������ 1�� �߰�
                break;

            default:
                Debug.Log($" {other.tag} : �� �� ���� �±��Դϴ�.");
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
        //        Debug.Log("CharacterCombatBase�� �������� �ʴ� �� ������Ʈ�� ����!!");
        //    }
        //}
    }
}
