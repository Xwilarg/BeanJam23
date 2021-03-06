using UnityEngine;

public class BirdIA : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;
    public float MinSpeed;
    public float Live;

    public bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        Speed = Random.Range(MinSpeed, MaxSpeed);
        if (isLeft) gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isLeft) transform.position += transform.right * Speed * Time.deltaTime;
        if (!isLeft) transform.position -= transform.right * Speed * Time.deltaTime;

        if (Live <= 0) Destroy(this.gameObject);
        Live -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Globe"))
        {
            collision.gameObject.GetComponent<GlobeInfo>().ApplyDamage();
            Destroy(gameObject);
        }
    }
}
