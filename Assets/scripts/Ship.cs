using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Ship : MonoBehaviour
{
	private CannonBallShooter CannonBallShooter;
	public Rigidbody rb;
	public Transform ShipModel;
	public int PlayerNumber;

	public KeyCode Up;
	public KeyCode Left;
	public KeyCode Right;
	public KeyCode ShootLeft;
	public KeyCode ShootRight;

	public float MinSpeed = 0.02f;
	public float MaxSpeed = 0.1f;
	float CurrentSpeed = 1.0f;
	public int Endurance = 5;

	public float MaxAngle = 30f;
	float CurrentAngle = 0;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		CannonBallShooter = gameObject.AddComponent<CannonBallShooter>();
	}

	void Update()
	{
		var targetSpeed = Input.GetKey(Up)? MaxSpeed : MinSpeed;
		CurrentSpeed = Mathf.Lerp(CurrentSpeed, targetSpeed, Time.deltaTime);

		var targetAngle = 0f;
		
		if(Input.GetKey(Left))
			targetAngle += -MaxAngle;

		if(Input.GetKey(Right))
			targetAngle += MaxAngle;

		if(Input.GetKey(ShootLeft))
			CannonBallShooter.Shoot("Left", PlayerNumber);

		if(Input.GetKey(ShootRight))
			CannonBallShooter.Shoot("Right", PlayerNumber);

		CurrentAngle = Mathf.Lerp(CurrentAngle, targetAngle, Time.deltaTime/2f);

		rb.rotation *= Quaternion.Euler(Vector3.up * CurrentAngle * Time.deltaTime);
		rb.velocity = rb.rotation * Vector3.forward * CurrentSpeed;

		float rotationX = Mathf.Sin(Time.timeSinceLevelLoad * 1.5f) * 2f;
		float rotationZ = CurrentAngle / 2f;

		ShipModel.localRotation = Quaternion.Euler(rotationX, 0, rotationZ);

		ShipGravity(ShipModel);
		//isLose();
	}

	// void OnCollisionEnter(Collision c)
	// {
	// 	var pos = transform.position;
	// 	Debug.Log(pos);
	// }

	void ShipGravity(Transform ShipModel)
	{
		if(ShipModel.position.y > 3f)
		{
			transform.position = new Vector3(transform.position.x, -1.04f, transform.position.z);
			transform.rotation = Quaternion.Euler(0f, transform.rotation.y, 0f);
			if(transform.rotation.x == 0f && transform.rotation.z == 0f)
			{
				rb.isKinematic = true;
				rb.isKinematic = false;
			}
		}

		if(ShipModel.position.y < -10f)
		{
			transform.position = new Vector3(transform.position.x, -1.04f, transform.position.z);
			transform.rotation = Quaternion.Euler(0f, transform.rotation.y, 0f);
			if(transform.rotation.x == 0f && transform.rotation.z == 0f)
			{
				rb.isKinematic = true;
				rb.isKinematic = false;
			}
			--Endurance;
		}
	}

	// void isLose()
	// {
	// 		if(Endurance <= 4){
		// 			var playAgain = false;
		// 		#if UNITY_EDITOR
		// 			playAgain = EditorUtility.DisplayDialog("Game Over","Czy chcesz zagrać jeszcze raz","Tak", "Nie");
		// 		#else
		// 			//playAgain = YOUROWNCLASS.DisplayDialog("Game Over","Czy chcesz zagrać jeszcze raz","Tak", "Nie");
		// 		#endif
		// 		if(!playAgain){
		// 			Application.Quit();
		// 		}
	// 		}
	// }
}
