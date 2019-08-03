using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hit)
    {

        if (hit.tag == "Player" || hit.tag == "Clone")
        {

            Health health = hit.gameObject.GetComponent<Health>();
        
            if (health != null)
            {
                health.Die();
                Object.Destroy(gameObject);
            }
           
        }
    }
}
