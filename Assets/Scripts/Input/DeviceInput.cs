using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceInput : MonoBehaviour
{
    private InputController inputController;

    private Vector2 position;

    private void Awake()
    {
        inputController = GetComponent<InputController>();
    }

    public void OnPosition(InputAction.CallbackContext callbackContext)
    {
        position = callbackContext.ReadValue<Vector2>();
        inputController.InputMoveEvent(position);
    }

    public void OnPress(InputAction.CallbackContext callbackContext)
    {
        switch (callbackContext.phase)
        {
            case InputActionPhase.Performed://시작
                inputController.InputStartEvent();
                break;

            case InputActionPhase.Canceled://중지
                inputController.InputEndEvent();
                break;
        }
    }
}
