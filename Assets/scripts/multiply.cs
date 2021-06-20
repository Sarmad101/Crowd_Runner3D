using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class multiply : MonoBehaviour
{
    //variables
    #region
    public Text MT1;
    int exactMultiplier = 0;
    string sign = null;
    private bool collided = false;
    private doubledStrength strength;
    #endregion
    void Start()
    {
        multipli();
        strength = GetComponentInParent<doubledStrength>();
    }

    
  void multipli()
    {
        
        //Plus
        int Pmultiply1 = Random.Range(5, 50);
        

        //multiply
        int multiplyerM1 = Random.Range(1, 3);
       

        if (Random.Range(1, 3) == 2)
        {
            MT1.text = "+"+Pmultiply1.ToString();
            exactMultiplier = Pmultiply1;
            sign = "+";
        }
        else
        {
            MT1.text = "x"+multiplyerM1.ToString();
            exactMultiplier = multiplyerM1;
            sign = "x";
        }


    }



    //spawn players
    #region
    void spawn()
    {
        GameObject[] gb = GameObject.FindGameObjectsWithTag("Player");
        Vector3 position;
        if (sign == "x") 
        {
            exactMultiplier *= gb.Length;

        }
        else
        {
            exactMultiplier += gb.Length;
        }


        for(int i = 0; i < exactMultiplier; i++)
        {
            position = new Vector3(Random.Range(gb[0].transform.position.x+1.5f, gb[0].transform.position.x-1.5f), 0f, Random.Range(gb[0].transform.position.z+1.5f, gb[0].transform.position.z - 1.5f));
            GameObject gbb = Instantiate(gb[0], position, Quaternion.identity);
            gbb.transform.SetParent(GameObject.FindGameObjectWithTag("mainCharacter").transform);
        }
        exactMultiplier += 1;
        GameObject.FindGameObjectWithTag("playercount").GetComponent<Text>().text = exactMultiplier.ToString();

    }
    #endregion



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !collided)
        {
            //only execute once between 2 portals at spawn points
            if (!strength.hasDoubled)
            {
                strength.hasDoubled = true;
                collided = true;
                spawn();
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraMove>().FindClosestPlayer();
                Renderer rend = GetComponent<Renderer>();
                rend.enabled = false;
                gameObject.SetActive(false);
            }
            
        }
    }
}
