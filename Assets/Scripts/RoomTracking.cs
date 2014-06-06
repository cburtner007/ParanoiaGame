using UnityEngine;
using System.Collections;

public class RoomTracking : MonoBehaviour {

	private int currRoomNum = 0;
	private RoomID currRoom = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.isStatic)
		{
			currRoom = other.gameObject.GetComponent<RoomID> ();
			currRoomNum = currRoom.roomID;
			Debug.Log ("Entered room: " + currRoomNum);
		}
	}
	
	//activates when another object exits the trigger area
	void OnTriggerExit(Collider other)
	{

	}
	
	void OnTriggerStay(Collider other)
	{
		
	}

	public int CurrentRoom
	{
		get
		{
			return currRoomNum;
		}
		set
		{
			currRoomNum = value;
		}
	}
}
