using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField]
    private float _xRange, _yRange;

    [SerializeField]
    private int _count;

    [SerializeField]
    private GameObject _starPrefab;

    [SerializeField]
    private Sprite[] _starSprites;

    private List<GameObject> _stars = new();
    private List<GameObject> _oldStars = new();
    private Transform _player;
    private int _pos;

    private float _nextPos;

    private void Start()
    {
        _player = transform.parent;
        SpawnStars();
    }

    private void FixedUpdate()
    {
        var p = CalculatePosition();
        if (_pos != p)
        {
            SpawnStars();
        }
    }

    private void SpawnStars()
    {
        Debug.Log("Respawn stars");
        foreach (var go in _oldStars)
        {
            Destroy(go);
        }
        _oldStars.Clear();
        _oldStars = new(_stars);
        _stars.Clear();
        for (int i = 0; i < _count; i++)
        {
            var go = Instantiate(_starPrefab, new Vector2(Random.Range(-_xRange, _xRange), Random.Range(-_yRange, _yRange) + _nextPos), Random.rotation);
            go.GetComponent<SpriteRenderer>().sprite = _starSprites[Random.Range(0, _starSprites.Length)];
            _stars.Add(go);
        }
        _pos = CalculatePosition();
        _nextPos += _yRange;
    }

    private int CalculatePosition()
    {
        return (int)(_player.transform.position.y / _yRange - _yRange / 2f);
    }
}
