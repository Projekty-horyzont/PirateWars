using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShooter : MonoBehaviour
{
    public GameObject CannonBallPrefab;

    public Vector3 SpawnPosition;
    public Vector3 ShootDirection;

    void Update()
    {
        if(!Input.GetKeyDown(KeyCode.Space)) return;

        var ball = Instantiate(CannonBallPrefab);
        ball.transform.position = transform.position + transform.rotation * SpawnPosition;

        var rb = ball.GetComponent<Rigidbody>();
        rb.velocity = transform.rotation * ShootDirection;
    }
}
