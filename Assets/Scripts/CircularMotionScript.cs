using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotionScript : MonoBehaviour {

    private float timeCounter = 0;

    public float speed = 0;
    public bool reverse = false;
    public Vector3 startingPosition;

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(5.0f, 10.0f);
        reverse = Random.Range(1, 3) % 2 == 0;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += speed * Time.deltaTime;
        float c = Mathf.Cos(timeCounter);
        float s = Mathf.Sin(timeCounter);
        float z = 0;
        transform.position = reverse ? startingPosition + new Vector3(c, s, z) : startingPosition + new Vector3(s, c, z);
    }
}
