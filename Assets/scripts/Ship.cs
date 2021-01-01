using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	public Rigidbody rb;
	public Transform ShipModel;
	
	public float MinSpeed = 0.02f;
	public float MaxSpeed = 0.1f;
	float CurrentSpeed = 1.0f;
	
	public float MaxAngle = 30f;
	float CurrentAngle = 0;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		var targetSpeed = Input.GetKey(KeyCode.W)? MaxSpeed : MinSpeed;			
		CurrentSpeed = Mathf.Lerp(CurrentSpeed, targetSpeed, Time.deltaTime);

		var targetAngle = 0f;
		if(Input.GetKey(KeyCode.A))
			targetAngle = -MaxAngle;

		if(Input.GetKey(KeyCode.D))
			targetAngle = MaxAngle;

		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
			targetAngle = 0;
		
		CurrentAngle = Mathf.Lerp(CurrentAngle, targetAngle, Time.deltaTime/2f);

		rb.rotation *= Quaternion.Euler(Vector3.up * CurrentAngle * Time.deltaTime);
		rb.velocity = rb.rotation * Vector3.forward * CurrentSpeed;

		float rotationX = Mathf.Sin(Time.timeSinceLevelLoad * 1.5f) * 2f;
		float rotationZ = CurrentAngle / 2f;

		ShipModel.localRotation = Quaternion.Euler(rotationX, 0, rotationZ);
	}
}
