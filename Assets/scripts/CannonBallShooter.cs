using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShooter : MonoBehaviour
{
    public GameObject CannonBallPrefab;

    public Vector3 LeftSpawnPosition;
    public Vector3 LeftShootDirection;

    public Vector3 RightSpawnPosition;
    public Vector3 RightShootDirection;
    
    public float ShootPeriod = 1f;
    float LastShootTime = 0f;

    private GameObject ball;
    private string Direction;
    private int ShipNumber;

    void Update()
    {
        if(!Input.GetKeyDown(KeyCode.Q)) return;

        // if(Direction == null) return;

        if(Time.timeSinceLevelLoad - LastShootTime < ShootPeriod) return;
        LastShootTime = Time.timeSinceLevelLoad;

        ball = Instantiate(CannonBallPrefab);
        var rb = ball.GetComponent<Rigidbody>();

        Debug.Log(this.Direction);

        switch(Direction)
        {
            case "Left":
                Direction = "Left";
                ball.transform.position = transform.position + transform.rotation * LeftSpawnPosition;
                rb = ball.GetComponent<Rigidbody>();
                rb.velocity = transform.rotation * LeftShootDirection;
                break;

            case "Right":
                Direction = "Right";
                ball.transform.position = transform.position + transform.rotation * RightSpawnPosition;
                rb = ball.GetComponent<Rigidbody>();
                rb.velocity = transform.rotation * RightShootDirection;
                break;
        }

        // if(!Input.GetKeyDown(KeyCode.Space)) return;

        // if(Time.timeSinceLevelLoad - LastShootTime < ShootPeriod) return;

        // LastShootTime = Time.timeSinceLevelLoad;

        // var camera = FindObjectOfType<PlayerCamera>();
        // var direction = camera.GetCameraLookDirection();

        // if(direction == CameraLookDirection.FORWARD || direction == CameraLookDirection.BACKWARD)
        //     return;

        // var lookLeft = direction == CameraLookDirection.LEFT;
        // var SpawnPosition = lookLeft ? LeftSpawnPosition : RightSpawnPosition;
        // var ShootDirection = lookLeft ? LeftShootDirection : RightShootDirection;

        // var ball = Instantiate(CannonBallPrefab);
        // ball.transform.position = transform.position + transform.rotation * SpawnPosition;

        // var rb = ball.GetComponent<Rigidbody>();
        // rb.velocity = transform.rotation * ShootDirection;
    }

    public void Shoot(string direction, int ship_number)
    {
        this.ShipNumber = ship_number;
        this.Direction = direction;
    }
}
