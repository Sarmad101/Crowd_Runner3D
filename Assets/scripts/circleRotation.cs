using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleRotation : MonoBehaviour
{
    public Vector3 speed;

   
    void FixedUpdate()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
