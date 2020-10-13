using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{

    public GameObject Platform;
    public bool StartPressed = false;
    public LevelPlatformsList platformListScript;
    private LevelControllerScript LevelControllerScript;
   

    // Start is called before the first frame update

    void Start()
    {
        LevelControllerScript = GameObject.Find("LevelController").GetComponent<LevelControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelControllerScript.HasStarted())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouse.z = 0;

                if (platformListScript.SelectedPlatforms.Count != 0)
                {
                    GameObject.Destroy(GameObject.FindGameObjectWithTag("Platform"));
                    Instantiate(platformListScript.SelectedPlatforms[0], mouse, platformListScript.SelectedPlatforms[0].transform.rotation);
                    platformListScript.UsePlatform();
                }
               
            }
        }
        
    }


    public void PressStart()
    {
        StartPressed = true;
        
    }
}
