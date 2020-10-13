using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{


   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Health health = col.gameObject.GetComponent<Health>();

            if (health != null)
            {
                health.Die();
            }
        }
    }


}
