using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class controller : MonoBehaviour
{

    //Veriables
    #region
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private Rigidbody rb;
    private Animator anim;
    [SerializeField]
    private float LookRadius = 5f , gravity = 10f;
    private bool hasObstacle = false;
    private CharacterController _controller;
    public bool enemyTrigger = false, victory = false;
    NavMeshAgent agent;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    private GameObject[] decals;
    [SerializeField]
    private GameObject[] bloods;
    private skinColor skin;
    private float distance;
    playersController control;
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;
    public float power = 10.0F;
    GameObject missionEnd;
    #endregion

    void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
        _controller = GetComponent<CharacterController>();
    }


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindClosestEnemy();
        skin = GetComponent<skinColor>();
        anim = GetComponent<Animator>();
        control = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<playersController>();
        EnableColliders(true);
        enableRigidbody(true);
        if (GameObject.FindGameObjectWithTag("boss") != null)
        {
            missionEnd = GameObject.FindGameObjectWithTag("boss");
        }
        else
        {
            missionEnd = GameObject.FindGameObjectWithTag("win");
        }

    }

    
    void Update()
    {

        if (!hasObstacle)
        {
            _run();
        }
        else
        {
            transform.Translate(Vector3.forward * gravity * Time.deltaTime);
        }

  
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
    }

    //Sense Triggers
    #region 

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            
            if (col.gameObject.GetComponent<enemies>() != null)
            {
                setBlood();
                setDecal();
                col.gameObject.GetComponent<enemies>().died();
                countplayers();
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
           
        }
        if (col.gameObject.tag == "tower")
        {
            setBlood();
            setDecal();
            col.gameObject.GetComponent<towerScript>().reduceSize();
            countplayers();
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "arrow")
        {
            setBlood();
            setDecal();
            countplayers();
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
      

        if (col.gameObject.tag == "boss")
        {
          
            StartCoroutine(attackToBoss(col));
            if (GameObject.FindGameObjectWithTag("playercounter") != null)
            {
                GameObject.FindGameObjectWithTag("playercounter").SetActive(false);
            }

        }

        if (col.gameObject.tag == "win")
        {
            if (!enemyTrigger)
            {
                gameObject.GetComponent<SwipeManager>().enabled = false; //Disabling movement
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraMove>().finalHasBegan = true;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraMove>().notToTurnToPlayerPositions = true;
            }
            enemyTrigger = true;
            agent.Stop();
            anim.SetLayerWeight(anim.GetLayerIndex("hit"), 0f);
            anim.Play("dance");
            Debug.Log("win");
            if (GameObject.FindGameObjectWithTag("playercounter") != null)
            {
                GameObject.FindGameObjectWithTag("playercounter").SetActive(false);
            }

        }




        if (col.gameObject.tag == "olfirst")
        {
            Debug.Log("Obstacle is here");
            if (!hasObstacle)
            {
                ControlRun();
                hasObstacle = true;
            }
        }
        

        if (col.gameObject.tag == "olsecond")
        {

            Debug.Log("Passed the obstacle");
            if (hasObstacle)
            {
                ControlAgent();
                hasObstacle = false;
            }
        }



        if (col.gameObject.tag == "obstacle")
        {
            countplayers();
            setBlood();
            setDecal();
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "jump")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jumped");
        }

        if (col.gameObject.tag == "death")
        {
            countplayers();
            setBlood();
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "circle")
        {
            col.gameObject.SetActive(false);
        }

    }

    #endregion


    void run()
    {

        if (enemy == null)
        {
            FindClosestEnemy();
            if (enemy == null)
            {
                agent.Stop();
                enemy = missionEnd;
                agent.SetDestination(enemy.transform.position);
                agent.Resume();
            }
            
        }

      
        distance = Vector3.Distance(enemy.transform.position, transform.position);
        agent.SetDestination(enemy.transform.position);

        if (distance <= LookRadius)
             {
                anim.SetLayerWeight(anim.GetLayerIndex("hit"), 1f);
             }
        else {
               anim.SetLayerWeight(anim.GetLayerIndex("hit"), 0f);
             }
            
    }
    void setDecal()
    {
        int index = 0;
        if (skin.color == "black")
        {
            index = 0;
        }
        if (skin.color == "green")
        {
            index = 1;
        }
        if (skin.color == "yellow")
        {
            index = 2;
        }
        if (skin.color == "blue")
        {
            index = 3;
        }
        if (skin.color == "red")
        {
            index = 4;
        }
        if (skin.color == "pink")
        {
            index = 5;
        }
        Instantiate(decals[index], transform.position, transform.rotation);
    }

    void setBlood()
    {
        int index = 0;
        if (skin.color == "black")
        {
            index = 0;
        }
        if (skin.color == "green")
        {
            index = 1;
        }
        if (skin.color == "yellow")
        {
            index = 2;
        }
        if (skin.color == "blue")
        {
            index = 3;
        }
        if (skin.color == "red")
        {
            index = 4;
        }
        if (skin.color == "pink")
        {
            index = 5;
        }
        Instantiate(bloods[index], transform.position, transform.rotation);
    }



    public void FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                enemy = go;
                distance = curDistance;
            }
        }

     
       
    }


    public void hitByBoss()
    {
        enemyTrigger = true;
        StopAllCoroutines();
        agent.enabled = false;
        agent.enabled = false;
        anim.enabled = false;
        gameObject.tag = "Untagged";
        EnableColliders(false);
        enableRigidbody(false);
        Collider cold = GetComponent<Collider>();
        cold.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, power, ForceMode.Impulse);
        setBlood();
        Destroy(this.gameObject,2f);
    }

  

    IEnumerator attackToBoss(Collider col)
    {
        yield return new WaitForSeconds(1f);
        col.gameObject.GetComponent<bossScript>().hp -= 2f;
        setBlood();
    }



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
                if (col == _controller)
                {

                }
                else
                {
                    col.isTrigger = colide;
                }
                
            }

        }

    }


    public void dustRight()
    {
       

    }public void dustleft()
    {
     
    }

    void countplayers()
    {
        if (GameObject.FindGameObjectWithTag("playercount") != null)
        {
            GameObject.FindGameObjectWithTag("playercount").GetComponent<Text>().text = (GameObject.FindGameObjectsWithTag("Player").Length - 1).ToString();
        }
    }



    void _run()
    {
        if (!enemyTrigger)
        {

            run();
        }

        if (enemyTrigger && !victory)
        {
            anim.Play("dance");
            agent.enabled = false;
            agent.enabled = false;
            victory = true;
        }
    }


    void ControlRun()
    {
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        agent.Stop();
        agent.enabled = false;

    }
    void ControlAgent()
    {
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        agent.enabled = true;
        agent.Stop();
        agent.Resume();
    }

}
