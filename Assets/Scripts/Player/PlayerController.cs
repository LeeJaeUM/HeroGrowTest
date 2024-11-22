using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 inputVecView = new Vector3();
    public Vector3 moveVec = new Vector3();
    public float speed = 2;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        AttachInputManager();
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + moveVec);
    }

    void PlayerMove(Vector2 inputVec)
    {
        inputVecView.x = inputVec.x;
        inputVecView.z = inputVec.y;
        moveVec = inputVecView * speed * Time.fixedDeltaTime;
    }

    void AttachInputManager()
    {
        InputManager.Instance.OnMoveAction += PlayerMove;
    }
}
