using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraLookDirection { FORWARD, RIGHT, BACKWARD, LEFT }

public class PlayerCamera : MonoBehaviour
{   
    public Transform ObjectToTrack;
    public Vector3 Delta;

    float cameraAngle = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        cameraAngle += Input.GetAxis("Mouse X");
        var quaternion = Quaternion.Euler(0f, cameraAngle, 0f);

        var position = ObjectToTrack.position
            + ObjectToTrack.rotation * quaternion * Delta;

        transform.position = position;

        transform.LookAt(ObjectToTrack);
        transform.rotation *= Quaternion.Euler(-10f, 0f,  0f);

        GetCameraLookDirection();
    }

    public CameraLookDirection GetCameraLookDirection()
    {
        var angle = Mathf.DeltaAngle(0, cameraAngle);

        if(-45 < angle && angle < 45)
            return CameraLookDirection.FORWARD;
        if(45 < angle && angle < 135)
            return CameraLookDirection.RIGHT;
        if(-135 < angle && angle < -45)
            return CameraLookDirection.LEFT;

        return CameraLookDirection.BACKWARD;
    }
}
