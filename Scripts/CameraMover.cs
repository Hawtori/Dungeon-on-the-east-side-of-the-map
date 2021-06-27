using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void Update()
    {
    }

    void FixedUpdate()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
       
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }

        //Vector3 pos = transform.position;
        //pos.x = GameObject.Find("Player").transform.position.x;
        //pos.y = GameObject.Find("Player").transform.position.y;
        //pos.z = transform.position.z;
        //transform.position = pos;
    }
}
