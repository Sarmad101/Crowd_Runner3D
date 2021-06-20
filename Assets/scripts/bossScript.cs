using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class bossScript : MonoBehaviour
{
    #region
    public float hp = 100f , distance , lookRadius = 5f;
    public bool bossDied = false;
    private cameraMove cam;
    private Animator anim;
    private NavMeshAgent agent;
    private GameObject players;
    public Slider slide;
    public Text hpText;
    int convertHp;
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;
    #endregion


    void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        FindClosestPlayer();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraMove>();

        //Disabling ragdoll
        EnableColliders(true);
        enableRigidbody(true);
    }

   
    void Update()
    {
        if (hp > 0f)
        {
            findPlayer();
           
        }
        else
        {
            if (!bossDied)
            {
               
                die();
                bossDied = true;
            }
        }

        if (hp < 1f)
        {
            hp = 0f;
            gameObject.tag = "Untagged";
            
        }

        slide.value = hp;
        convertHp = (int)hp;
        hpText.text = convertHp.ToString() + "%";
       
    }

    void findPlayer()
    {
        if (players == null)
        {
            //finds player again if previous closest player got killed
            FindClosestPlayer();
            agent.Stop();
            agent.Resume();
            if (players == null)
            {
                //executes when all players are dead
                agent.Stop();
                anim.Play("dance");
                anim.SetLayerWeight(anim.GetLayerIndex("attack"), 0f);
            }
        }
        else
        {
            //Boss AI
            distance = Vector3.Distance(players.transform.position, transform.position);
            if (distance <= lookRadius)
            {
                agent.SetDestination(players.transform.position);
                anim.Play("run");
                anim.SetLayerWeight(anim.GetLayerIndex("attack"), 1f);

                //below 2 variables are used for letting camera follow the boss instead of players
                cam.finalHasBegan = true;
                cam.notToTurnToPlayerPositions = true;
            }
        }
    }


    //for editor gismo only for development not necessory you can remove gismos code
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    //Ragdoll functions
    #region

    void enableRigidbody(bool kinematicc)
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb == null)
            {
                break;
            }
            rb.isKinematic = kinematicc;
        }
    }


    void EnableColliders(bool colide)
    {
        foreach (Collider col in colliders)
        {
            if (col == null)
            {
                break;
            }
            else
            {

                col.isTrigger = colide;
            }


        }

    }

    #endregion


    void die()
    {
        //enabling the ragdoll and disabling the animator nd NavMeshAgent
        EnableColliders(false);
        enableRigidbody(false);
        agent.Stop();
        agent.enabled = false;
        anim.enabled = false;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject playerss in players)
        {
            playerss.GetComponent<controller>().enemyTrigger = true;
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
                players = go;
                distance = curDistance;
            }
        }

    }
}
