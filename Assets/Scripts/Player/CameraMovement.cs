using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; //Tracking
    public Vector3 offset; //Give more flexibility



    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
