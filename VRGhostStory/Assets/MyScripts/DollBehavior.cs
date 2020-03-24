using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollBehavior : MonoBehaviour
{
    public GameObject head;
    public Animator anim;
    public AudioSource audioS;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "doll")
        {

            head.transform.Rotate(260f, 180f, 170f, Space.Self);
            //anim.Play("HeadBug");
            audioS.Play();
                       
            Destroy(other);
        }
    }
}
