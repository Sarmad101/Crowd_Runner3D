using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwipeManager : MonoBehaviour
{
    /// <summary>
    /// Script for moving player left and right
    /// </summary>
    private Touch touch;
    [SerializeField]
    private float speed;

    void Update()
    {
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                    //you can use lerp function instead of below code depends upon you
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + touch.deltaPosition.x * speed, gameObject.transform.position.y, gameObject.transform.position.z);
                    if (gameObject.transform.position.x < -3.53f)
                    {
                        gameObject.transform.position = new Vector3(-3.53f, gameObject.transform.position.y, gameObject.transform.position.z);
                    }
                    else if (gameObject.transform.position.x > 3.53f)
                    {
                        gameObject.transform.position = new Vector3(3.53f, gameObject.transform.position.y, gameObject.transform.position.z);
                    }
                  
            }
           
        }
    }


}