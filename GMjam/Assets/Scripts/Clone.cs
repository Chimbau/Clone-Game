using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ClonePrefab;
    public float spawnDistance;
    public float cooldownTimer;
    public float cooldown;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MakeAClone();

        if (cooldownTimer >= 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }


    void MakeAClone()
    {
        if (Input.GetKey(KeyCode.Q) && cooldownTimer < 0)
        {
            Instantiate(ClonePrefab, transform.position - new Vector3(spawnDistance, 0, 0), transform.rotation);
            cooldownTimer = cooldown;
        }
        else
        {
            if (Input.GetKey(KeyCode.E) && cooldownTimer < 0)
            {
                Instantiate(ClonePrefab, transform.position + new Vector3(spawnDistance, 0, 0), transform.rotation);
                cooldownTimer = cooldown;
            }
        }
    }
}
