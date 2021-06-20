using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemies : MonoBehaviour
{
    //variables
    #region
    public float distance;
    [SerializeField]
    private bool hasBow = false;
    [SerializeField]
    private GameObject arrow;
    NavMeshAgent agent;
    GameObject players;
    private bool playerskilled = false;
    private float LookRadius = 5f;
    [SerializeField]
    private GameObject blood;
    [SerializeField]
    private GameObject decal;
    Animator anim;
    #endregion

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        find();
    }
    void find()
    {
        if (players == null)
        {
            //if player is missing
            players = GameObject.FindGameObjectWithTag("Player");
            if (players == null && !playerskilled)
            {
                //if there is no player in scene
                agent.enabled = false;
                playerskilled = true;
                GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<playersController>().playersAlive = false;
                anim.Play("dance");
            }

        }
        if (!playerskilled)
        {
            //fight scene
            distance = Vector3.Distance(players.transform.position, transform.position);
            if (distance <= LookRadius)
            {
                agent.SetDestination(players.transform.position);
                anim.Play("run");
            }
            if (hasBow)
            {
                if (distance <= 25f && distance >= 5f)
                {
                    anim.Play("bow");
                }
            }
        }
    }


    //executes when player collides with enemy
    public void died()
    {
       Instantiate(blood, transform.position, transform.rotation);
       Instantiate(decal, transform.position, transform.rotation);

    }


    //its event called from bow animation
    void hitBow()
    {
        if (arrow != null)
        {
            Instantiate(arrow, transform.position, transform.rotation);
        }
    }

}
