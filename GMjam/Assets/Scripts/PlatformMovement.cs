using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    private Vector3 StartPoint;
    public Vector3 EndPoint;
    public float speed;
    public float waitTime;
    private Vector3 temp;
    private float StartTime;
    private float distancia;
    private float distanciaPercorrida;


    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        StartPoint = transform.position;
        //EndPoint = new Vector3(7.54f, 1.92f, 0);
        distancia = Vector3.Distance(StartPoint, EndPoint);
        waitTime = 2f;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        distanciaPercorrida = (Time.time - StartTime) * speed;
        float lerpFrac = distanciaPercorrida / distancia;
        transform.position = Vector3.Lerp(StartPoint, EndPoint, lerpFrac);

    }


    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        temp = StartPoint;
        StartPoint = EndPoint;
        EndPoint = temp;
        //EndPoint = new Vector3(0.32f, 1.92f, 0);
        distanciaPercorrida = 0;
        StartTime = Time.time;

        yield return new WaitForSecondsRealtime(waitTime);
        temp = StartPoint;
        StartPoint = EndPoint;
        EndPoint = temp;

        // EndPoint = new Vector3(7.3f, 1.92f, 0);
        distanciaPercorrida = 0;
        StartTime = Time.time;

        StartCoroutine(Timer());


    }
}
