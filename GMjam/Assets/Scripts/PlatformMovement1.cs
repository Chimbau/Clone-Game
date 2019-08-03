using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement1 : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector3 StartPoint;

    public Vector3 EndPoint;
    private Vector3 temp;
    public float speed;

    private float waitTimeTimer;
    public float waitTime;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPoint = transform.position;
        waitTimeTimer = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        if (Vector3.Distance(transform.position, EndPoint) > 0.2)
        {
            
            direction = (EndPoint - StartPoint).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            if (waitTimeTimer < 0)
            {
                temp = EndPoint;
                EndPoint = StartPoint;
                StartPoint = temp;
                waitTimeTimer = waitTime;
            }
            else
            {
                waitTimeTimer -= Time.deltaTime;
            }
            
        }
       

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector3(100, 0, 0);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.parent = null;
        }
    }
}
