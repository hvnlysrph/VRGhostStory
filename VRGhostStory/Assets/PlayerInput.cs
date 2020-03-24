using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static UnityAction<bool> onHasController = null;

    public static UnityAction onTriggerUp = null;
    public static UnityAction onTriggerDown = null;
    public static UnityAction onTouchpadUp = null;
    public static UnityAction onTouchpadDown = null;

    private bool hasController = false;
    private bool inputActive = true;

    // Update is called once per frame
    void Update()
    {

        hasController = CheckForcontroller(hasController);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            
                onTriggerDown();
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
                onTriggerUp();
        }

        float triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

        if(triggerValue > 0.5f)
        {

        }
    }

    private bool CheckForcontroller(bool value)
    {
        bool controllerCheck = OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) ||
            OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote);

        if(value == controllerCheck)
        {
            return value;
        }

        if (onHasController != null)
        {
            onHasController(value);
        }

        return controllerCheck;
    }
}
