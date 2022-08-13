using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControl : MonoBehaviour
{
    [Range(0, 25f)] [SerializeField] float movementSpeed = 2f;
    [SerializeField] private InputReader inputReader = default;

    PlayerInputActions playerInput;
    Rigidbody2D characterRigidbody;
    Vector2 movementVector;

    private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputReader.moveEvent += OnMove;
    }

    private void OnDisable()
    {
        inputReader.moveEvent -= OnMove;
    }

    private void Update()
    {
        characterRigidbody.velocity = movementVector * movementSpeed;
    }

    private void OnMove(Vector2 moveInput)
    {
        movementVector = moveInput;
    }

}
