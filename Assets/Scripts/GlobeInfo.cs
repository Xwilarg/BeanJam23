using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeInfo : MonoBehaviour
{

    public float Live;
    // Start is called before the first frame update

    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AplyDamage(float d)
    {
        animator.SetTrigger("Hit");
        Live -= d;
        if (Live <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
