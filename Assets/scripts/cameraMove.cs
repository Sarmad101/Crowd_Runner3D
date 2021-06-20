using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
   
    public GameObject players;
    public bool playersDied = false;
    public bool finalHasBegan = false, notToTurnToPlayerPositions = false;
    private bool endTimeArrived = false;
    
    void Start()
    {
     
        findPlayers();
     
    }

    //Late update for making sure everything would run smooth
    void LateUpdate()
    {
        //executes if camera didn't see boss
        if (!notToTurnToPlayerPositions)
        {
            //if player is missing and game has not ended
            if (players == null && !playersDied)
            {
                findPlayers();
            }
            else
            {
                if (!playersDied)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, players.transform.position.z - 8.92f);
                }
            }
        }
        else
        {
            //this executes when camera sees the boss
            if (finalHasBegan)
            {
                if (GameObject.FindGameObjectWithTag("boss") != null)
                {
                    //let camera notice the boss rather than players
                    transform.LookAt(GameObject.FindGameObjectWithTag("boss").transform.position);
                }
                else
                {
                    if (!endTimeArrived) 
                    {
                        StartCoroutine(sceneReload(3.0f));
                        endTimeArrived = true;
                    }
                }
                if (players == null)
                {
                    findPlayers();
                }
              
            }
            notToTurnToPlayerPositions = true;
           
        }
    }
   
    private void findPlayers()
    {
     
        FindClosestPlayer();
        if (players==null)
        {
            //destroys all the arrows if all players will die
            playersDied = true;
            GameObject[] gb = GameObject.FindGameObjectsWithTag("arrow");
            foreach(GameObject gb2 in gb)
            {
                Destroy(gb2);
            }
            Destroy(GameObject.FindGameObjectWithTag("playercounter"));
            StartCoroutine(sceneReload(4.0f));
        }

    }

    //finds nearest player to make sure all players are in the camera view
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

    
    IEnumerator sceneReload(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    
}
