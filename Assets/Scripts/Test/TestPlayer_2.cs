using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer_2 : MonoBehaviour
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
        InputManager.OnMoveAction += PlayerMove;
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + moveVec);
    }

    void PlayerMove(Vector2 inputVec)
    {
        print("Test프레이어2 에서 이동중");
        inputVecView.x = inputVec.x;
        inputVecView.z = inputVec.y;
        moveVec = inputVecView * speed * Time.fixedDeltaTime;
    }
}
