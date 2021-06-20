using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    Vector3 pos;
 
   public void reduceSize()
    {
        //reduces the size of the tower if players collide to it
        pos = new Vector3(transform.position.x, (transform.position.y - 0.5f), transform.position.z);
        transform.position = pos;

        if (transform.position.y < 0f)
        {
            Destroy(gameObject.transform.parent.gameObject);
           
        }
    }
}
