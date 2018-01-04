using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour {

    public float moveSpeed;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    public float zoomSpeed;
    public float zoomMax;
    public float zoomMin;

    public float lerpSpeed;

    private Vector3 nextPosition;

    // Use this for initialization
    void Start ()
    {
        nextPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        nextPosition.x += Input.GetAxis("Horizontal") * moveSpeed;
        nextPosition.x = nextPosition.x < minX ? minX : nextPosition.x;
        nextPosition.x = nextPosition.x > maxX ? maxX : nextPosition.x;

        nextPosition.y += Input.GetAxis("Vertical") * moveSpeed;
        nextPosition.y = nextPosition.y < minY ? minY : nextPosition.y;
        nextPosition.y = nextPosition.y > maxY ? maxY : nextPosition.y;
        
        nextPosition.z += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        nextPosition.z = nextPosition.z < zoomMin ? zoomMin : nextPosition.z;
        nextPosition.z = nextPosition.z> zoomMax ? zoomMax : nextPosition.z;

        if(Input.GetButton("Fire3"))
        {
            nextPosition = new Vector3(0, 0, -30);
        }
        
        transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * lerpSpeed);
    }
}
