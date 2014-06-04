using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float x = target.position.x;
		float y = target.position.y;
		float z = target.position.z;
		transform.position = new Vector3 (x, y + 10, z - 12);
	}
}
