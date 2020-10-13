using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightScript : MonoBehaviour
{

    public int plateWeight = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Clone")
        {
            plateWeight++;
            Physics2D.GetIgnoreLayerCollision(9, 9);
        }
      
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Clone")
        {
            plateWeight--;
        }

    }
}
