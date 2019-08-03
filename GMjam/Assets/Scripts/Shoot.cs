using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Bullet;
    public float bulletSpeed;
    public float fireRateTimer;
    public float fireRate;

    private Transform ShootPoint;

    // Start is called before the first frame update
    void Start()
    {
        ShootPoint = transform.Find("ShootPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRateTimer <= 0)
        {
            Bullet.GetComponent<BulletMovement>().SetSpeed(bulletSpeed);
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);

            fireRateTimer = fireRate;
        }
        else
        {
            fireRateTimer -= Time.deltaTime;
        }
    }
}
