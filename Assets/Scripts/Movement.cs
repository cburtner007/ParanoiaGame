using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private float ACCELERATION = 10f;
	private float SPEED_CAP = 0.14f;
	public float speedH;
	public float speedV;
	public float speedZ;

	public Transform velocity;

	// Use this for initialization
	void Start () {
		speedH = 0;
		speedV = 0;
		speedZ = 0;
	}
	
	// Update is called once per frame
	void Update () {
		speedH = Input.GetAxisRaw ("Horizontal") * ACCELERATION * Time.deltaTime;
		speedV = Input.GetAxisRaw ("Vertical") * ACCELERATION * Time.deltaTime;
		speedZ = Input.GetAxisRaw ("Jump") * ACCELERATION * Time.deltaTime;

		if (Mathf.Abs (speedH) > SPEED_CAP && speedH > 0)
			speedH = SPEED_CAP;
		else if (Mathf.Abs (speedH) > SPEED_CAP && speedH < 0)
			speedH = -SPEED_CAP;

		if (Mathf.Abs(speedV) > SPEED_CAP && speedV > 0)
			speedV = SPEED_CAP;
		else if (Mathf.Abs(speedV) > SPEED_CAP && speedV < 0)
			speedV = -SPEED_CAP;

		if (Mathf.Abs(speedZ) > SPEED_CAP && speedZ > 0)
			speedZ = SPEED_CAP;

		//Debug.Log ("H: " + speedH + " V: " + speedV);

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
			rigidbody.AddForce (new Vector3(speedH, 0, 0), ForceMode.Impulse);
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
			rigidbody.AddForce (new Vector3(0, 0, speedV), ForceMode.Impulse);
		if (Input.GetKey(KeyCode.Q))
			rigidbody.AddForce (new Vector3(0, speedZ, 0), ForceMode.Impulse);

		transform.LookAt (velocity);
	}
}
