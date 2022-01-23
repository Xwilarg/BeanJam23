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

    private void Start()
    {
        SpawnStars();
    }

    private void SpawnStars()
    {
        foreach (var go in _stars)
        {
            Destroy(go);
        }
        _stars.Clear();
        for (int i = 0; i < _count; i++)
        {
            var go = Instantiate(_starPrefab, (Vector2)transform.position + new Vector2(Random.Range(-_xRange, _xRange), Random.Range(-_yRange, _yRange)), Random.rotation);
            go.GetComponent<SpriteRenderer>().sprite = _starSprites[Random.Range(0, _starSprites.Length)];
            _stars.Add(go);
        }
    }
}
