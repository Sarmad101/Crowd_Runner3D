using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public ParticleSystem particles;
    public ParticleSystem axeright, axeleft;
    private bool switchState = false;
    public void PlayParticles()
    {
        particles.Play();
    }
    public void axeRight()
    {
        axeright.Play();
    }
    public void axeLeft()
    {
        axeleft.Play();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!switchState)
            {
                //executes when switching cones and lift states
                switchState = true;
                if (transform.parent.parent.Find("Cone") != null)
                {
                    transform.parent.parent.Find("Cone").gameObject.GetComponent<Animator>().Play("anim");
                }
            }
        }
    }
}
