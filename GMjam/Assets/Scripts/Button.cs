using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public bool Pressed = false;

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player" || collider.tag == "Clone")
        {
            Pressed = true;

        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag == "Clone")
        {
            Pressed = false;

        }
    }

    public bool isPressed()
    {
        return Pressed;
    }
}
