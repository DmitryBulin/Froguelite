using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControl : MonoBehaviour
{
    [Range(0, 25f)] [SerializeField] private float _movementSpeed = default;
    [SerializeField] private InputReader _inputReader = default;
    
    Rigidbody2D _characterRigidbody;
    Vector2 _movementVector = default;

    private void Awake()
    {
        _characterRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= OnMove;
    }

    private void Update()
    {
        _characterRigidbody.velocity = _movementVector * _movementSpeed;
    }

    private void OnMove(Vector2 moveInput)
    {
        _movementVector = moveInput;
    }

}
