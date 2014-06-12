using UnityEngine;
using System.Collections;

public class WallFade : MonoBehaviour {

	public RoomTracking currRoom;
	public int wallID;

	private Renderer rend;

	private Color notHidden;
	private Color hidden;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer> ();
		//this shader allows for changing of the alpha of a material
		rend.material.shader = Shader.Find( "Transparent/Diffuse" );
		notHidden = rend.material.color;
		hidden = notHidden;
		hidden.a = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		//if the room the player is in matches this walls id, make it transparent
		if (currRoom.CurrentRoom == wallID)
		{
			rend.material.color = hidden;
		}
		else
			rend.material.color = notHidden;
	}
}
