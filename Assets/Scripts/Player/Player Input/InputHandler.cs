using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputHandler", menuName = "InputHandler")]
public class InputHandler : ScriptableObject , Controls.IGamePlayActions
{
    #region Input Events
    public event UnityAction fireEvent = delegate { };
    public event UnityAction switchWeaponEvent = delegate { };
    public event UnityAction<Vector2> moveVectorEvent = delegate { };
    public event UnityAction pauseEvent = delegate { };

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
 

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveVectorEvent.Invoke(context.ReadValue<Vector2>());
    }


    public void OnSwitchWeapon(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            switchWeaponEvent.Invoke();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            fireEvent.Invoke();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            pauseEvent.Invoke();
    }

    #endregion

}
