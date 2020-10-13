using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform InitialPosition;
    private GameObject LevelPlatformList;
    private TrailRenderer trail;

    void Start()
    {
        LevelPlatformList = GameObject.Find("LevelPlatforms");
        trail = GetComponent<TrailRenderer>();
    }


    public void Die()
    {
        //Object.Destroy(gameObject);
        //Instantiate(gameObject, InitialPosition.position, gameObject.transform.rotation);
        //trail.enabled = false;

        transform.position = InitialPosition.position;
        trail.Clear();
        //trail.enabled = true;
        LevelPlatformList.GetComponent<LevelPlatformsList>().UseBackup();

    }
}
