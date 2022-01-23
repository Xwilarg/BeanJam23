using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool isLeft = false;
    public GameObject Bird;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject bird = Instantiate(Bird, transform.position, transform.rotation);
        bird.GetComponent<BirdIA>().isLeft = isLeft;
    }
}
