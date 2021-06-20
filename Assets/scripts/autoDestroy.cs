using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroy : MonoBehaviour
{
    public float Time = 2f;
    void Start()
    {
        Destroy(gameObject, Time);
    }

   
}
