using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnEnemies : MonoBehaviour
{
    /// <summary>
    /// this script can be attached to any object you want to spawn
    /// </summary>
    [SerializeField]
    private GameObject enemies;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private int count=20;
    private Vector3 position;
    void Start()
    {
        int counter = 0;
        
        for (int a = 0; a <= (Random.Range(1,count)); a++)
        {
            position = new Vector3(Random.Range(enemies.transform.position.x + 1.5f, enemies.transform.position.x - 1.5f), enemies.transform.position.y, Random.Range(enemies.transform.position.z + 1.5f, enemies.transform.position.z - 1.5f));
            GameObject gb =  Instantiate(enemies, position, enemies.transform.rotation);
            gb.transform.SetParent(this.transform);
            counter++;
        }
        if (enemyText != null)
        {
            enemyText.text = counter.ToString();
        }
    }

    
}
