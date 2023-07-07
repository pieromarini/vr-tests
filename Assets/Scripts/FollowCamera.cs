using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera followCamera;
    public float distance = 3.0F;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = followCamera.transform.TransformPoint(new Vector3(0, -0.3f, distance));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        var lookAtPos = new Vector3(followCamera.transform.position.x, transform.position.y, followCamera.transform.position.z);
        transform.LookAt(lookAtPos);
        transform.forward *= -1;
    }
}