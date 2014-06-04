using UnityEngine;
using System.Collections;

public class PlayerVector : MonoBehaviour {

	public Movement moving;
	public Transform player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 velocity = new Vector3 (player.position.x + moving.speedH*20, 0.5f, player.position.z + moving.speedV*20);
		transform.position = velocity;

		//Debug.Log (moving.speedH*100);
	}
}
