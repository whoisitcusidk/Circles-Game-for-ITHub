using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private bool _isJumping = false;

    private PlayerInput _playerInput;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnEnable()
    {
        _playerInput.OnJumpStarted += Jump;
        _playerInput.OnJumpCanceled += StopJump;
    }

    public void OnDisable()
    {
        _playerInput.OnJumpStarted -= Jump;
        _playerInput.OnJumpCanceled -= StopJump;
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            _rb.AddForceY(_jumpForce);
        }
    }

    private void Jump()
    {
        _isJumping = true;
    }

    private void StopJump()
    {
        _isJumping = false;
    }
}
