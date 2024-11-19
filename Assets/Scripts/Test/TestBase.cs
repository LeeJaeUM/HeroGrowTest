using UnityEngine;
using UnityEngine.InputSystem;

public class TestBase : MonoBehaviour
{
    Test_InputAction testInputAction;

    protected virtual void Awake()
    {
        testInputAction = new Test_InputAction();
    }

    protected virtual void OnEnable()
    {
        testInputAction.Enable();
        testInputAction.Test.Test1.performed += OnTest1;
        testInputAction.Test.Test2.performed += OnTest2;
        testInputAction.Test.Test3.performed += OnTest3;
        testInputAction.Test.Test4.performed += OnTest4;
    }

    protected virtual void OnTest1(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTest2(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTest3(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTest4(InputAction.CallbackContext context)
    {

    }
}
