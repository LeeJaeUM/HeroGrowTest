using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    InputSystem_Actions inputActions;

    public Vector3 inputVec = new Vector3();
    public float speed = 2;
    Rigidbody rigid;


    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMove;
    }

    private void FixedUpdate()
    {
        Vector3 nextVec = inputVec*speed*Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputAction.CallbackContext context)
    {
        inputVec.x = context.ReadValue<Vector2>().x;
        inputVec.z = context.ReadValue<Vector2>().x;

    }    
    
    // 액션 맵을 전환하는 메서드
    public void SwitchActionMap(string actionMapName)
    {
       // inputActions.SwitchCurrentActionMap(actionMapName);
    }
}
