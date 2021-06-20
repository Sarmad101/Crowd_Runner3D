using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    /// <summary>
    /// This script is just for testing purpose, 
    /// You can use loops for assigning varous positions,
    /// It can be more efficient if you use renderer block size :)
    /// I didn't use loop cause I wanted to test it for prototype, its not the final result of whole game and still a lot of things can be improved
    /// </summary>
    [SerializeField]
    private GameObject[] levels;
    [SerializeField]
    private float[] startnew;

    void Awake()
    {
      
            int number = Random.Range(0, 15);

            if (number == 13 || number == 14 || number == 15)
            {
                number = Random.Range(0, 12);
            }

            levels[number].transform.position = new Vector3(transform.position.x, 0f, startnew[0]);
            levels[number].SetActive(true);
      
            number = Random.Range(0, 16);

      
            if (number == 13 || number == 14 || number == 15)
            {
                number = Random.Range(0, 12);
            }

            levels[number].transform.position = new Vector3(transform.position.x, 0f, startnew[1]);
            levels[number].SetActive(true);
        
            int enemy = Random.Range(13, 16);
            levels[enemy].transform.position = new Vector3(transform.position.x, 0f, startnew[2]);
            levels[enemy].SetActive(true);
       
            number = Random.Range(0, 15);

        
            if (number == 13 || number == 14 || number == 15)
            {
                number = Random.Range(0, 12);
            }

            levels[number].transform.position = new Vector3(transform.position.x, 0f, startnew[3]);
            levels[number].SetActive(true);


            number = Random.Range(0, 15);


            if (number == 13 || number == 14 || number == 15)
            {
                number = Random.Range(0, 12);
            }

            levels[number].transform.position = new Vector3(transform.position.x, 0f, startnew[4]);
            levels[number].SetActive(true);

            number = Random.Range(16, 18);

            levels[number].transform.position = new Vector3(transform.position.x, 0f , startnew[5]);
            levels[number].SetActive(true);





    }
   



}
