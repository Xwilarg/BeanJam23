using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdIA : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;
    public float MinSpeed;
    public float Live;
    public float Damage;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Globe")
        {
            collision.gameObject.GetComponent<GlobeInfo>().AplyDamage(Damage);
            Destroy(gameObject);
        }
    }
}
