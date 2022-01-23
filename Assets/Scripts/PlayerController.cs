using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private const float _force = 50f;

    private bool _isGoingUp;

    [SerializeField]
    private TMP_Text _scoreDisplay;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGoingUp = Input.GetKey(KeyCode.Space);
        _scoreDisplay.text = $"{(int)transform.position.y} meter{((int)transform.position.y > 1 ? "s" : "")}";
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector2.up * (_isGoingUp ? 1f : 0f) * _force);
        _rb.velocity = new Vector2(0f, Mathf.Clamp(_rb.velocity.y, -5f, 5f));
    }
}
