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

    // Events are assigned to empty delegates to avoid null checking

    // Gameplay
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction AttackEvent = delegate { };
    public event UnityAction InteractEvent = delegate { };
    public event UnityAction DodgeEvent = delegate { };
    public event UnityAction PauseEvent = delegate { };
    public event UnityAction FirstItemUseEvent = delegate { };
    public event UnityAction SecondItemUseEvent = delegate { };
    public event UnityAction ThirdItemUseEvent = delegate { };

    // UI navigation
    public event UnityAction<Vector2> NavigationEvent = delegate { };
    public event UnityAction SelectEvent = delegate { };
    public event UnityAction ExitEvent = delegate { };

    private PlayerInputActions _gameInput;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new PlayerInputActions();
            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.Menu.SetCallbacks(this);
        }

        EnableGameplayInput();
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            AttackEvent.Invoke();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            InteractEvent.Invoke();
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            DodgeEvent.Invoke();
        }
    }

    public void OnFirstItem(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            FirstItemUseEvent.Invoke();
        }
    }

    public void OnSecondItem(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            SecondItemUseEvent.Invoke();
        }
    }

    public void OnThirdItem(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ThirdItemUseEvent.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseEvent.Invoke();
        }
    }
    
    public void OnNavigate(InputAction.CallbackContext context)
    {
        NavigationEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            SelectEvent.Invoke();
        }
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ExitEvent.Invoke();
        }
    }

    public void EnableGameplayInput()
    {
        _gameInput.Gameplay.Enable();
        _gameInput.Menu.Disable();
    }

    public void EnableMenuInput()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.Menu.Enable();
    }

    public void DisableAllInput()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.Menu.Disable();
    }

}
