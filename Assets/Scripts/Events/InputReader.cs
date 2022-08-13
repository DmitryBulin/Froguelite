using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

/// <summary>
/// This class is responsible for handling input from Unity Input System
/// There are callbacks on all interactions - they raise corresponding events
/// </summary>

[CreateAssetMenu(menuName = "Events/Player Input Channel")]
public class InputReader : ScriptableObject, PlayerInputActions.IGameplayActions, PlayerInputActions.IMenuActions
{
    // Gameplay
    public event UnityAction<Vector2> moveEvent = delegate { };
    public event UnityAction attackEvent = delegate { };
    public event UnityAction interactEvent = delegate { };
    public event UnityAction dodgeEvent = delegate { };
    public event UnityAction pauseEvent = delegate { };
    public event UnityAction firstItemUseEvent = delegate { };
    public event UnityAction secondItemUseEvent = delegate { };
    public event UnityAction thirdItemUseEvent = delegate { };

    // UI navigation
    public event UnityAction<Vector2> navigationEvent = delegate { };
    public event UnityAction selectEvent = delegate { };
    public event UnityAction exitEvent = delegate { };

    private PlayerInputActions gameInput;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new PlayerInputActions();
            gameInput.Gameplay.SetCallbacks(this);
            gameInput.Menu.SetCallbacks(this);
        }

        EnableGameplayInput();
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (moveEvent != null)
        {
            moveEvent.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (attackEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            attackEvent.Invoke();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (interactEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            interactEvent.Invoke();
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (dodgeEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            dodgeEvent.Invoke();
        }
    }

    public void OnFirstItem(InputAction.CallbackContext context)
    {
        if (firstItemUseEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            firstItemUseEvent.Invoke();
        }
    }

    public void OnSecondItem(InputAction.CallbackContext context)
    {
        if (secondItemUseEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            secondItemUseEvent.Invoke();
        }
    }

    public void OnThirdItem(InputAction.CallbackContext context)
    {
        if (thirdItemUseEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            thirdItemUseEvent.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (pauseEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            pauseEvent.Invoke();
        }
    }
    
    public void OnNavigate(InputAction.CallbackContext context)
    {
        if (navigationEvent != null)
        {
            navigationEvent.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (selectEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            selectEvent.Invoke();
        }
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        if (exitEvent != null
            && context.phase == InputActionPhase.Performed)
        {
            exitEvent.Invoke();
        }
    }

    public void EnableGameplayInput()
    {
        gameInput.Gameplay.Enable();
        gameInput.Menu.Disable();
    }

    public void EnableMenuInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.Menu.Enable();
    }

    public void DisableAllInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.Menu.Disable();
    }

}
