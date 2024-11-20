using UnityEngine;

public class CharacterCombatBase : MonoBehaviour
{
    // 체력 관련 변수
    [SerializeField]
    protected float curHealth;
    public float MaxHealth { get; protected set; } = 100f; // 최대 체력 (기본값 100)

    [SerializeField]
    protected float attackPower = 5.0f;
    public float AttackPower { get => attackPower; protected set { attackPower = value; } }


    // 체력 프로퍼티: 읽기 가능, 쓰기 제한 (최소 0, 최대 MaxHealth)
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

    // 초기화
    protected virtual void Start()
    {
        CurHealth = MaxHealth; // 시작 시 체력을 최대치로 설정
    }

    // 데미지를 받는 함수
    protected virtual void TakeDamage(float damage)
    {
        CurHealth -= damage; // 데미지를 받으면 Health 프로퍼티가 자동으로 최소값 처리
        Debug.Log($"{gameObject.name}이 {damage} 데미지를 받음. 남은 체력: {CurHealth}");
    }

    // 체력 회복 함수
    protected virtual void Heal(float amount)
    {
        CurHealth += amount; // 회복량을 더하면 Health 프로퍼티가 자동으로 최대값 처리
        Debug.Log($"{gameObject.name}이 {amount} 체력을 회복함. 현재 체력: {CurHealth}");
    }

    protected virtual void Die()
    {
        Debug.Log($"!!{gameObject.name}이 사망했습니다 남은 체력: {CurHealth}!!");
    }
}
