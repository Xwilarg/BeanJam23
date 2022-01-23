using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private const float _force = 50f;

    private bool _isGoingUp;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGoingUp = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        Debug.Log(_isGoingUp);
        _rb.AddForce(Vector2.up * (_isGoingUp ? 1f : 0f) * _force);
    }
}
