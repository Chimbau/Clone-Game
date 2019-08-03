using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTime : MonoBehaviour
{

    private float PlatformTimeTimer;
    public float PlatformTimer;

    // Start is called before the first frame update
    void Start()
    {
        PlatformTimeTimer = PlatformTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();   
    }

    void Destroy()
    {
        if (PlatformTimeTimer <= 0)
        {
            GameObject.Destroy(gameObject);

        }
        else
        {
            PlatformTimeTimer -= Time.deltaTime;
        }


    }
}
