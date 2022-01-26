using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float dampTime = 0.15f;
     public Vector3 velocity;
     public Transform target;
     // Update is called once per frame
     void Update () 
     {
        transform.position = new Vector3(target.position.x+velocity.x, target.position.y+velocity.y, velocity.z);

     
     }
}
