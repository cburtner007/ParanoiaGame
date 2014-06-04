using UnityEngine;
using System.Collections;

public class PlayerVector : MonoBehaviour {
	
	public Transform player;
	public CharacterController character;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//a vector is first set to the player's current position
		velocity = player.position;

		//add in the characters velocity based on the CharacterController component
		velocity += character.velocity;

		//set this object to that position
		transform.position = velocity;

		//Debug.Log (moving.speedH*100);
	}
}
