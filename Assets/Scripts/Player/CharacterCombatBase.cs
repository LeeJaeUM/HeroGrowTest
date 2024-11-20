using UnityEngine;

public class CharacterCombatBase : MonoBehaviour
{
    // ü�� ���� ����
    [SerializeField]
    protected float curHealth;
    public float MaxHealth { get; protected set; } = 100f; // �ִ� ü�� (�⺻�� 100)

    [SerializeField]
    protected float attackPower = 5.0f;
    public float AttackPower { get => attackPower; protected set { attackPower = value; } }


    // ü�� ������Ƽ: �б� ����, ���� ���� (�ּ� 0, �ִ� MaxHealth)
    public float CurHealth
    {
        get => curHealth;
        protected set
        {
            //if(curHealth == value) return;
            curHealth = Mathf.Clamp(value, 0, MaxHealth);

            if (curHealth <= 0)
                Die();
        }
    }

    // �ʱ�ȭ
    protected virtual void Start()
    {
        CurHealth = MaxHealth; // ���� �� ü���� �ִ�ġ�� ����
    }

    // �������� �޴� �Լ�
    protected virtual void TakeDamage(float damage)
    {
        CurHealth -= damage; // �������� ������ Health ������Ƽ�� �ڵ����� �ּҰ� ó��
        Debug.Log($"{gameObject.name}�� {damage} �������� ����. ���� ü��: {CurHealth}");
    }

    // ü�� ȸ�� �Լ�
    protected virtual void Heal(float amount)
    {
        CurHealth += amount; // ȸ������ ���ϸ� Health ������Ƽ�� �ڵ����� �ִ밪 ó��
        Debug.Log($"{gameObject.name}�� {amount} ü���� ȸ����. ���� ü��: {CurHealth}");
    }

    protected virtual void Die()
    {
        Debug.Log($"!!{gameObject.name}�� ����߽��ϴ� ���� ü��: {CurHealth}!!");
    }
}
