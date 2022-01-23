using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool isLeft = false;
    public GameObject Bird;

    public void Spawn()
    {
        if (transform.position.y > 10f)
        {
            GameObject bird = Instantiate(Bird, transform.position, transform.rotation);
            bird.GetComponent<BirdIA>().isLeft = isLeft;
        }
    }
}
