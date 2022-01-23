using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobeInfo : MonoBehaviour
{
    [SerializeField]
    private int _lives;

    [SerializeField]
    private GameObject _healthPrefab;

    [SerializeField]
    private Transform _canvas;

    private List<GameObject> _hearts = new();

    private void Start()
    {
        int size = 32;
        for (int i = 0; i < _lives; i++)
        {
            var go = Instantiate(_healthPrefab, _canvas);
            go.transform.position += Vector3.right * size * i;
            _hearts.Add(go);
        }
    }

    public void ApplyDamage()
    {
        Destroy(_hearts.Last());
        _hearts.RemoveAt(_hearts.Count - 1);
        if (!_hearts.Any())
        {
            Debug.Log("GameOver");
        }
    }

    public bool IsAlive => _hearts.Any();
}
