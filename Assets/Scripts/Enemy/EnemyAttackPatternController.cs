using UnityEngine;

//public enum AttackPattern
//{
//    Pattern0 = 0,
//    Pattern1 = 1,
//    Pattern2 = 2,
//}

public class EnemyAttackPatternController : MonoBehaviour
{
    public float attackDelay = 3f;
    public float curAttackDelay = 0;
    public float attackDistance = 9f;


    public bool canAttack = false;
    public bool isAttacking = false;

    //private AttackPattern curAttackPattern;
    //public AttackPattern CurAttackPattern
    //{
    //    get => curAttackPattern;
    //    private set => curAttackPattern = value;
    //}


    public Transform target;

    private void Start()
    {
        SetTarget();
    }

    private void Update()
    {
    }

    //public bool CheckChaseable()
    //{
    //    //공격중일떄
    //    if (isAttacking)
    //    {

    //    }
    //    return !isAttacking;
    //}

    //돌진패턴
    //십자 레이저 패턴



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
