using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 inputVecView = new Vector3();
    public Vector3 moveVec = new Vector3();
    public float speed = 2; 
    private float rotateSpeed = 10.0f;

    private int animID_isMove = Animator.StringToHash("isMove");
    //readonly int animID_InputX = Animator.StringToHash("InputX");
    //readonly int animID_InputY = Animator.StringToHash("InputY");

    Rigidbody rigid;
    Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        AttachInputManager();
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + moveVec);
        if(moveVec != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVec);
            rigid.MoveRotation(Quaternion.Slerp(rigid.rotation, targetRotation, Time.fixedDeltaTime * rotateSpeed));
        }
         
    }

    void PlayerMove(Vector2 inputVec)
    {
        inputVecView.x = inputVec.x;
        inputVecView.z = inputVec.y;
        moveVec = inputVecView * speed * Time.fixedDeltaTime;

        if(inputVec.x == 0 && inputVec.y == 0)
        {
            animator.SetBool(animID_isMove, false);
        }
        else
        {
            animator.SetBool(animID_isMove, true);
        }

    }

    void AttachInputManager()
    {
        GameManager.Instance.InputManager.OnMoveAction += PlayerMove;
    }
}
