using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{

    public GameObject Platform;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;

            GameObject.Destroy(GameObject.FindGameObjectWithTag("Platform"));
            Instantiate(Platform, mouse, Platform.transform.rotation);
        }
    }
}
