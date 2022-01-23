using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawner[] Spawners;

    public float MinTimeToSpawn;
    public float MaxTimeToSpawn;
    public float RestTimeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCouldowns();
    }

    public void CheckCouldowns()
    {
        if(RestTimeToSpawn <= 0)
        {
            RestTimeToSpawn = Random.Range(MinTimeToSpawn, MaxTimeToSpawn);
            Spawners[Random.Range(0, Spawners.Length)].Spawn();
        }
        else
        {
            RestTimeToSpawn -= Time.deltaTime;
        }

    }
}
