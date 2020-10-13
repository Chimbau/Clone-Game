using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControllerScript : MonoBehaviour
{

    public GameObject StartPanel;
    public GameObject SelectPlatformPanel;
    public GameObject FinalPainel;
    private bool started = false;

    private GameObject LevelPlatformList;

    // Start is called before the first frame update
    void Start()
    {
        LevelPlatformList = GameObject.Find("LevelPlatforms");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            LevelPlatformList.GetComponent<LevelPlatformsList>().ResetPlatformSelection();
            StartPanel.SetActive(true);
            SelectPlatformPanel.SetActive(true);
            started = false;
        }
    }
    public void PressedStart()
    {
        started = true;
        StartPanel.SetActive(false);
        SelectPlatformPanel.SetActive(false);
        LevelPlatformList.GetComponent<LevelPlatformsList>().MakeBackUp();
    }

    public bool HasStarted()
    {
        return started;
    }


    public void NextPhase()
    {
        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
   
}
