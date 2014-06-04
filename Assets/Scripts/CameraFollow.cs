using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	//the object to follow
	public Transform target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float x = target.position.x;
		float y = target.position.y;
		float z = target.position.z;
		//set the camera to a position relative to the target object
		//the numbers are made up and can be adjusted depending on the desired perspective
		transform.position = new Vector3 (x, y + 10, z - 12);
	}
}
