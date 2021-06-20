using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<controller>().hitByBoss();
            gameObject.GetComponentInParent<bossScript>().hp -= 1f;
        }
    }
}
