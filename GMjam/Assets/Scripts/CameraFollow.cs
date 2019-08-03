using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform PlayerPosition;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (PlayerPosition != null)
        {
            Vector3 EndPosition = new Vector3(PlayerPosition.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, EndPosition, ref velocity, smoothTime);
        }
      
    }
}
