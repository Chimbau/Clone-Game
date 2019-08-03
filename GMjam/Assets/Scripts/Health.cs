using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void Die()
    {
        Object.Destroy(gameObject);
    }
}
