using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class playersController : MonoBehaviour
{
    //variables
    #region
    [SerializeField]
    private float gravity = 2f;
    public bool playersAlive = true;
    NavMeshAgent agent;
    GameObject players;
    #endregion

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
       
        if (players == null)
        {
            //find closest player if player is missing
            FindClosest();
        }
        else
        {
            agent.SetDestination(players.transform.position);
        }

    }


    //finding player
    public void FindClosest()
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
                players = go;
                distance = curDistance;
            }
        }



    }

}
