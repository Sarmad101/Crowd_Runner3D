using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class arrowScript : MonoBehaviour
{

    private GameObject player;
    private NavMeshAgent agent;
    void Start()
    {
        FindClosestPlayer();
        agent = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        if (player != null)
        {
            //if there is a player, arrow follows it
            agent.SetDestination(player.transform.position);
        }
        else
        {
            FindClosestPlayer();
        }
    }


    //Find closest player
    public void FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                player = go;
                distance = curDistance;
            }
        }

    }
}
