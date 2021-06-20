using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerEnemies : MonoBehaviour
{
    /// <summary>
    /// this code is just for make tower guard enemies to dance if players die
    /// </summary>
    private Animator anim;
    private bool hasPlayerDied = false;
    private GameObject players;
    void Start()
    {
        players = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (players == null && !hasPlayerDied)
        {
            players = GameObject.FindGameObjectWithTag("Player");
            if (players == null)
            {
                hasPlayerDied = true;
                anim.Play("dance");
            }
        }
    }
}
