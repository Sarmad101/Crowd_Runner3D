using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UIScript : MonoBehaviour
{
    
    void Awake()
    {
        //for idle position state before start of game
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("idle");
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().speed = 0f;
    }

   public void StartGame()
    {
        //Game begins :)
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().speed = 10f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("run2");
    }
}
