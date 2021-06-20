using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

public class PlayScript : MonoBehaviour, IPointerDownHandler
{

    [SerializeField]
    private GameObject UI_Component , countText;
    public void OnPointerDown(PointerEventData eventData)
    {

        UI_Component.SetActive(false);
        countText.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().speed = 10f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("run2");

    }


}
