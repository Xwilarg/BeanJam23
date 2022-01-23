using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera camera;
    private Transform Playertransform;
    public Color StartColor;
    public Color EndColor;
    public float SpaceDistance;
    // Start is called before the first frame update
    void Start()
    {
        Playertransform = GameObject.Find("Player").GetComponent<Transform>();
        camera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.backgroundColor = Color.Lerp(StartColor, EndColor, Playertransform.position.y/ SpaceDistance );
    }
}
