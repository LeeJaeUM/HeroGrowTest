using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    CharacterHP characterHP;

    private bool isInvincible = false;  // 무적 상태를 나타내는 변수
    public float invincibilityDuration = 0.3f;  // 무적 상태 지속 시간


    private void Start()
    {
        characterHP = GetComponent<CharacterHP>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    #region HP and Invincible
    public void IncreasePlayerHealth(float amount)
    {
        if (characterHP != null)
        {
            characterHP.IncreaseHP(amount);
        }
    }
    public void DecreasePlayerHealth(float amount)
    {
        if (!isInvincible && characterHP != null)
        {
            characterHP.DecreaseHP(amount);
            StartCoroutine(BecomeInvincible());  // 피격 후 무적 상태로 전환
        }
    }

    //플레이어 무적 상태 추가
    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;
        Debug.Log("무적 시작 : Player is invincible!");
        yield return new WaitForSeconds(invincibilityDuration);  // 무적 상태 지속 시간 동안 대기
        isInvincible = false;
        Debug.Log("무적 종료 : Player is no longer invincible.");
    }
    #endregion

}
