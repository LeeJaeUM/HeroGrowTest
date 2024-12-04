using UnityEngine;

public class EnemyAttackPatternController : MonoBehaviour
{
    public float attackDelay = 3f;
    public float curAttackDelay = 0;
    public float attackDistance = 9f;
    public int curPatternIndex = 0;
    public int maxPatternIndex = 1;

    public float dashDistance = 10f;
    public float dashSpeed = 6f;

    public bool canAttack = false;

    public Transform target;

    private void Start()
    {
        SetTarget();
        SettingPattern(0);
    }

    private void Update()
    {
        curAttackDelay += Time.deltaTime;
    }

    //돌진패턴
    //십자 레이저 패턴
    public bool CheckAttackable()
    {
        bool result = false;
        if(curAttackDelay > attackDelay && GetDistanceToPlayer() < attackDistance)
        {
            curAttackDelay = 0;
            result = true;
        }

        return result;
    }
    public bool CheckPatternMoveable()
    {
        bool result = false;
        if (curPatternIndex == 0)
        {
            result = true;
        }
        return result;
    }


    public void SettingPattern(int index)
    {
        curPatternIndex = index;
        switch (index)
        {
            case 0:
                SetPatternParmeters(3f, 6f);
                break;
            case 1:
                SetPatternParmeters(5f, 12f);
                break;
        }
    }

    private void SetPatternParmeters(float _atkDelay, float _atkDistance)
    {
        attackDelay = _atkDelay;
        attackDistance = _atkDistance;
        
    }



    #region 기존 base에서 가져온 함수 

    private float GetDistanceToPlayer()
    {
        Vector3 directionToPlayer = GetDirectionToPlayer();

        float distanceToPlayer = directionToPlayer.magnitude;
        float result = distanceToPlayer;

        return result;
    }
    private Vector3 GetDirectionToPlayer()
    {
        Vector3 directionToPlayer = target.position - transform.position;
        directionToPlayer.y = 0; // 높이 차이는 무시
        return directionToPlayer;
    }
    private void SetTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player 태그를 가진 오브젝트를 찾을 수 없습니다!");
        }
    }
    #endregion

}
