using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedPosition : MonoBehaviour
{
    public void PickedUp()
    {

        transform.localPosition = new Vector3(-0.18f ,1f,0f);
        transform.localRotation = Quaternion.Euler(-71.53f, 4f, -18.8f);
    }

    public void Dropped()
    {
        transform.localPosition = new Vector3(0,0,0);

        transform.localRotation = Quaternion.Euler(-90f,0,0);
    }
}
