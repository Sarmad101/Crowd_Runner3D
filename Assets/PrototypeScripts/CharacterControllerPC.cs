using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControllerPC : MonoBehaviour
{

    public Transform Pos;
    public float jumpForce = 10f;
    bool blooddrip = false;
    public Dropdown m_Dropdown;
    public Material[] skins;
    public GameObject[] decal, blood;
    int index = 0;

    void Start()
    {
        m_Dropdown.onValueChanged.AddListener(delegate { getSkin(m_Dropdown); });
    }
    void getSkin(Dropdown dropdown)
    {
       
        gameObject.GetComponentInChildren<Renderer>().material = skins[dropdown.value];
        index = dropdown.value;
    }

    void LateUpdate()
    {

      

        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            this.transform.Translate(0, 0, 10f * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            this.transform.Translate(0, 0, -10f * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up, -50 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up, 50 * Time.deltaTime);
        }

       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "lowerground")
        {
            Debug.Log("Collided");
            transform.position = Pos.position;
        }
        if (col.gameObject.tag == "jump")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.GetComponent<enemies>() != null)
            {
               
                col.gameObject.GetComponent<enemies>().died();
               
                Destroy(col.gameObject);
               
              
            }
        }


        if (col.gameObject.tag == "tower")
        {
           
            col.gameObject.GetComponent<towerScript>().reduceSize();
            Instantiate(blood[index], transform.position, transform.rotation);
          
        }
        if (col.gameObject.tag == "obstacle")
        {
            onDeath();
            StartCoroutine(respawn());
        }
    }
    void onDeath()
    {
        if (!blooddrip)
        {
            Instantiate(decal[index], new Vector3(transform.position.x, 0.06f, transform.position.z), transform.rotation);
            Instantiate(blood[index], transform.position, transform.rotation);
            blooddrip = true;
        }
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = Pos.position;
        blooddrip = false;
    }

   
}
