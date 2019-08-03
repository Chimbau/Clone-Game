using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPhase : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Passou de Fase");
        }
    }
}
