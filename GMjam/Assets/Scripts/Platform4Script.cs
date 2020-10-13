using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform4Script : MonoBehaviour
{

    public float force;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //col.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, force);
        }
    }
}
