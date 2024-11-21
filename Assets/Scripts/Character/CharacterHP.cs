using System;
using UnityEngine;

public class CharacterHP : MonoBehaviour
{
    public bool isDead = false;
    public event Action onDead;

    // ü�� ���� ����
    [SerializeField]
    protected float curHP;
    [SerializeField]
    protected float maxHP = 100f;
    public float MaxHP { get => maxHP; protected set { maxHP = value; } }  // �ִ� ü�� (�⺻�� 100)

    // ü�� ������Ƽ: �б� ����, ���� ���� (�ּ� 0, �ִ� MaxHealth)
    public float CurHP
    {
        get => curHP;
        protected set
        {
            //if(curHealth == value) return;
            curHP = Mathf.Clamp(value, 0, MaxHP);

            if (curHP <= 0)
                Die();
        }
    }

    // �ʱ�ȭ
    protected virtual void Start()
    {
        CurHP = MaxHP; // ���� �� ü���� �ִ�ġ�� ����
    }

    // ü�� ȸ�� �Լ�
    public void IncreaseHP(float amount)
    {
        Debug.Log($"{gameObject.name}�� {amount} ü���� ȸ����. ���� ü��: {CurHP}");
        CurHP += amount; // ȸ������ ���ϸ� Health ������Ƽ�� �ڵ����� �ִ밪 ó��
    }

    // ü�� ���� �Լ�
    public void DecreaseHP(float amount)
    {
        Debug.Log($"{gameObject.name}�� {amount} ü���� ������. ���� ü��: {CurHP}");
        CurHP -= amount; 
    }
    
    protected virtual void Die()
    {
        Debug.Log($"!! {gameObject.name}�� ����߽��ϴ� ���� ü��: {CurHP} !!");
        isDead = true;
        onDead?.Invoke();
    }
}
