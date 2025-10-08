using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    private float _dispersion;
    private float _horizontalSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = -_horizontalSpeed;
        _rb.AddForceY(Random.Range(-_dispersion, _dispersion));
    }

    public void Initialize(float speed, float dispersion)
    {
        _horizontalSpeed = speed;
        _dispersion = dispersion;
    }
}
