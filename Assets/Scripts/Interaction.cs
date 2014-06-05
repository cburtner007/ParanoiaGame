﻿using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

	private Renderer rend;
	private Movement move;
	private GameObject clone;
	public GameObject player;

	private bool inRange = false;
	private bool inspecting = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		move = player.GetComponent<Movement>();

	}
	
	// Update is called once per frame
	void Update () {
		if (inRange)
		{
			//"Jump" is set to the Spacebar by default
			if (Input.GetButtonDown("Jump") && !inspecting)
			{
				inspecting = true;
				//stops the players movement (see Movement script)
				move.inspecting = true;
				rend.material.color = (Color.green);

				//draw a duplicate object in close up view
				float x = player.transform.position.x;
				float y = player.transform.position.y;
				float z = player.transform.position.z;
				clone = (GameObject) Instantiate(this.gameObject, new Vector3(x, y + 9, z -10), Quaternion.Euler(new Vector3(30, 0, 0)));
				clone.rigidbody.useGravity = false;
				clone.renderer.material.color = Color.magenta;
				clone.rigidbody.freezeRotation = true;
				clone.rigidbody.Sleep();

				Debug.Log("Created");
			}

			//destroy the close up object and reset variables
			else if (Input.GetButtonDown("Jump") && inspecting)
			{
				Destroy(clone);
				inspecting = false;
				move.inspecting = false;
				Debug.Log("Deleted");
			}
		}



	}

	//activates when another object enters the trigger area
	//note this is the "Is Trigger" box collider that has an independent size, NOT the one used for direct collisions
	void OnTriggerEnter(Collider other)
	{
		//only does something when the player enters the area
		if (other.gameObject.Equals (player) && !Input.GetButton("Jump")) {
			inRange = true;
			rend.material.color = (Color.yellow);
			Debug.Log("Entered range");
		}
	}

	//activates when another object exits the trigger area
	void OnTriggerExit(Collider other)
	{
		//only does something when the player enters the area
		if (other.gameObject.Equals (player)) {
			inRange = false;
			inspecting = false;
			rend.material.color = (Color.red);
			Debug.Log("Exited range");
		}
	}

	void OnTriggerStay(Collider other)
	{
		
	}
}