using System.Threading;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _moveForce;

    private Rigidbody2D _rb;

    [SerializeField] private float _maxTimer;
    private float _timer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;

        if (_timer >= _maxTimer)
        {
            _rb.AddForceY(Random.Range(-_moveForce, _moveForce));
        }

        _rb.linearVelocityX = -_horizontalSpeed;
    }
}
