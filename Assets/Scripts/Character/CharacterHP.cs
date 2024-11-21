using System;
using UnityEngine;

public class CharacterHP : MonoBehaviour
{
    public bool isDead = false;
    public event Action onDead;

    // 체력 관련 변수
    [SerializeField]
    protected float curHP;
    [SerializeField]
    protected float maxHP = 100f;
    public float MaxHP { get => maxHP; protected set { maxHP = value; } }  // 최대 체력 (기본값 100)

    // 체력 프로퍼티: 읽기 가능, 쓰기 제한 (최소 0, 최대 MaxHealth)
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

    // 초기화
    protected virtual void Start()
    {
        CurHP = MaxHP; // 시작 시 체력을 최대치로 설정
    }

    // 체력 회복 함수
    public void IncreaseHP(float amount)
    {
        Debug.Log($"{gameObject.name}이 {amount} 체력을 회복함. 현재 체력: {CurHP}");
        CurHP += amount; // 회복량을 더하면 Health 프로퍼티가 자동으로 최대값 처리
    }

    // 체력 감소 함수
    public void DecreaseHP(float amount)
    {
        Debug.Log($"{gameObject.name}이 {amount} 체력을 감소함. 현재 체력: {CurHP}");
        CurHP -= amount; 
    }
    
    protected virtual void Die()
    {
        Debug.Log($"!! {gameObject.name}이 사망했습니다 남은 체력: {CurHP} !!");
        isDead = true;
        onDead?.Invoke();
    }
}
