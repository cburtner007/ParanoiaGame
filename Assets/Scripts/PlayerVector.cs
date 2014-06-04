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
		velocity = player.position;
		velocity += character.velocity;
		transform.position = velocity;

		//Debug.Log (moving.speedH*100);
	}
}
