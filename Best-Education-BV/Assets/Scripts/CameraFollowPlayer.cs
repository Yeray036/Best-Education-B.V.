using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	//this script will make sure the camera will chase the space shuttle no matter what.
    public Transform spaceShuttle;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (QA.activateSpaceShuttle)
        {
            Vector3 desiredPos = spaceShuttle.position + offset;
            transform.position = desiredPos;
        }
    }
}
