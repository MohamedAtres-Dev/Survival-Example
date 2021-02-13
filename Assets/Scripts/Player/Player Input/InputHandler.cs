using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputHandler", menuName = "InputHandler")]
public class InputHandler : ScriptableObject , Controls.IGamePlayActions
{
    #region Input Events
    public event UnityAction moveRightEvent = delegate { };
    public event UnityAction moveLeftEvent = delegate { };
    public event UnityAction moveUpEvent = delegate { }; // Used to talk, pickup objects, interact with tools like the cooking cauldron
    public event UnityAction moveDownEvent = delegate { }; // Used to bring up the inventory
    public event UnityAction fireEvent = delegate { };
    public event UnityAction switchWeaponEvent = delegate { };
    public event UnityAction<Vector2> moveVectorEvent = delegate { };

    private Controls playerInput;
    #endregion

    #region Monobehaviour
    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new Controls();
            playerInput.GamePlay.SetCallbacks(this);
        }
        playerInput.GamePlay.Enable();
    }

    private void OnDisable()
    {
        playerInput.GamePlay.Disable();
    }
    #endregion

    #region Input Handle
    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            moveDownEvent.Invoke();
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            moveLeftEvent.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveVectorEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            moveRightEvent.Invoke();
    }

    public void OnMoveUp(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            moveUpEvent.Invoke();
    }

    #endregion

}
