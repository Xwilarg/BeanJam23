using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private const float _force = 50f;

    private bool _isGoingUp;

    private AudioSource _source;
    private GlobeInfo _globe;

    [SerializeField]
    private TMP_Text _scoreDisplay;

    private float _newVel;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
        _globe = GetComponent<GlobeInfo>();
    }

    private void Update()
    {
        if (!_globe.IsAlive)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _source.Play();
            _newVel += .5f;
        }
        _scoreDisplay.text = $"{(int)transform.position.y} meter{((int)transform.position.y > 1 ? "s" : "")}";
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector2.up * _newVel * _force, ForceMode2D.Impulse);
        _newVel = 0f;
        _rb.velocity = new Vector2(0f, Mathf.Clamp(_rb.velocity.y, -5f, 7f));
    }
}
