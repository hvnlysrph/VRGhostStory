using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;
using VRTK.Prefabs.Interactions.Interactors;

public class OrbInteraction : MonoBehaviour
{
    Hand leftHandPos, rightHandPos;
    public Transform leftHand;
    public Transform rightHand;
    public Transform orbContainer;
    public GameObject playerPos;
    public GameObject ghostOrb;
    public GameObject[] followPts;
    

    Vector3 movementDir;


    const float movementDistance = 0.1f, movementSpeed = 1f;
    bool anchorCamera;
    float dist;
    int spwnPt = 0;

    /************************************************/
    private void Awake()
    {
        //PlayerInput.onTriggerDown += GoToHand;

    }

    void Start()
    {
        leftHandPos = leftHand.GetComponent<Hand>();
        rightHandPos = rightHand.GetComponent<Hand>();

        anchorCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (anchorCamera)
        {
            FollowPlayer();
        }

        Invoke("LeadPlayer", 10f);

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
    }

 
    /*public void GoToHand()
    {
        anchorCamera = false;

        movementDir = (leftHand.position - transform.position).normalized;

        if ((transform.position - leftHand.position).magnitude > movementDistance)
        {
            transform.Translate(movementDir * Time.deltaTime * movementSpeed);
        }

    }*/

}
