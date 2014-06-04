using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;

	public Transform velocity;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//the character controller is used for simple movement
		CharacterController controller = GetComponent<CharacterController>();

		//if the character is on the ground
		if (controller.isGrounded) {
			//read in the inputs, for digital (like a keyboard) 0 = not pressed and 1 = pressed
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}

		//continuously attempt to pull the character down due to a fake gravity
		moveDirection.y -= gravity * Time.deltaTime;
		//move the character based on the vector above
		controller.Move(moveDirection * Time.deltaTime);

		//force the player to look in the direction it's moving as long as it has some speed
		if (Mathf.Abs(moveDirection.x) + speed/2 >= speed || Mathf.Abs(moveDirection.z) + speed/2 >= speed)
			transform.LookAt (velocity.position);

	}
}
