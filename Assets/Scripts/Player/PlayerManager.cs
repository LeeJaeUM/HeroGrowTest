using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    CharacterHP characterHP;

    private bool isInvincible = false;  // ���� ���¸� ��Ÿ���� ����
    public float invincibilityDuration = 0.3f;  // ���� ���� ���� �ð�


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
            StartCoroutine(BecomeInvincible());  // �ǰ� �� ���� ���·� ��ȯ
        }
    }

    //�÷��̾� ���� ���� �߰�
    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;
        Debug.Log("���� ���� : Player is invincible!");
        yield return new WaitForSeconds(invincibilityDuration);  // ���� ���� ���� �ð� ���� ���
        isInvincible = false;
        Debug.Log("���� ���� : Player is no longer invincible.");
    }
    #endregion

}
