using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;
using VRTK.Prefabs.Interactions.Interactors;

public class OrbBehavior : MonoBehaviour
{
    public GameObject movePoint;
    public Transform orbContainer;
    public GameObject playerPos;
    public GameObject ghostOrb;
    public GameObject[] followPts;
    

    Vector3 movementDir;


    const float movementDistance = 0.1f;
    float movementSpeed = 1f;
    private bool anchorCamera = true, anchorHand = false;
    float dist;
    int spwnPt = 0;

    public bool AnchorCamera
    {
        set
        {
            anchorCamera = value;
        }
    }

    /************************************************/
    private void Awake()
    {
        //PlayerInput.onTriggerDown += GoToHand;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (anchorCamera)
        {
            FollowPlayer();
        }
        else if (anchorHand)
        {
            GoToHand();
        }

        //Invoke("LeadPlayer", 10f);

        dist = Vector3.Distance(playerPos.transform.position, transform.position);
        

    }

    private void FollowPlayer()
    {
        movementDir = (orbContainer.position - transform.position).normalized;

        if((transform.position-orbContainer.position).magnitude > movementDistance)
        {
            transform.Translate(movementDir * Time.deltaTime * movementSpeed);
        }
        
    }

    private void LeadPlayer()
    {
        anchorCamera = false;

        if (spwnPt < followPts.Length)
        {
            bool canMove = true;
            GameObject transportPt = followPts[spwnPt].transform.GetChild(0).gameObject;
            movementDir = (followPts[spwnPt].transform.position - transform.position).normalized;

            transportPt.SetActive(true);

            if ((transform.position - followPts[spwnPt].transform.position).magnitude > 0.5f && canMove)
            {
                transform.Translate(movementDir * Time.deltaTime * 3f);

            }
            else
            {
                canMove = false;

                if (dist < 2.5)
                {
                    transportPt.SetActive(false);
                    spwnPt++;
                    LeadPlayer();
                }
            }

        }
        else
        {
            anchorCamera = true;
        }
    }

 
    void GoToHand()
    {
        Debug.Log("go to hand");
        anchorCamera = false;

        movementDir = (movePoint.transform.position - transform.position).normalized;

        if ((transform.position - movePoint.transform.position).magnitude > .01)
        {
            transform.Translate(movementDir * Time.deltaTime * movementSpeed);
        }

    }

    public void Summoned()
    {
        anchorCamera = false;
        anchorHand = true;
    }

    public void Released()
    {
        anchorHand = false;
        anchorCamera = true;
    }

}
