using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float speed = 1.19f;
    public Vector3 pointA;
    public Vector3 pointB;

    void Start()
    {
        //pointA = new Vector3(-2, 1.5f, -7f);
        //pointB = new Vector3(-2, 1.5f, 7f);
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}
