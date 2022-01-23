using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobeInfo : MonoBehaviour
{
    [SerializeField]
    private int _lives;

    [SerializeField]
    public GameObject GameOverMenu;

    public float Live;
    // Start is called before the first frame update

    public Animator animator;

    [SerializeField]
    private GameObject _healthPrefab;

    [SerializeField]
    private Transform _canvas;

    private List<GameObject> _hearts = new();

    private void Start()
    {
        Time.timeScale = 1;
        int size = 40;
        for (int i = 0; i < _lives; i++)
        {
            var go = Instantiate(_healthPrefab, _canvas);
            go.transform.position += Vector3.right * size * i;
            _hearts.Add(go);
        }
    }

    public void ApplyDamage()
    {
        animator.SetTrigger("Hit");
        Destroy(_hearts.Last());
        _hearts.RemoveAt(_hearts.Count - 1);
        if (!_hearts.Any())
        {
            GameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public bool IsAlive => _hearts.Any();

    public static void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
