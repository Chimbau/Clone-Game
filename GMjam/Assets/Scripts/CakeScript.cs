using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeScript : MonoBehaviour
{
    public GameObject NextPhasePanel;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            NextPhasePanel.SetActive(true);
        }
    }
}
