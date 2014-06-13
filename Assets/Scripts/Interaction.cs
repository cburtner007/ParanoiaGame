using UnityEngine;
using System.Collections;
using UnityEditor;

public class Interaction : MonoBehaviour {

	private Renderer rend;
	private Movement move;
	private GameObject clone;
	public GameObject player;
	public GameObject targetChild;

	private bool inRange = false;
	private bool inspecting = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		move = player.GetComponent<Movement>();
		//InvokeRepeating("CheckVisible", 0.0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		//var forward = transform.TransformDirection(Vector3.forward) * 10;
		//Debug.DrawRay (transform.position, Vector3.forward * 10, Color.green, 5.0f);
		CheckVisible ();
		if (inRange)
		{
			//"Jump" is set to the Spacebar by default
			if (Input.GetButtonDown("Jump") && !inspecting)
			{
				inspecting = true;
				//stops the players movement (see Movement script)
				move.inspecting = true;
				Renderer comp = targetChild.GetComponent<Renderer>();
				
				comp.material.color = (Color.green);

				//draw a duplicate object in close up view
				float x = player.transform.position.x;
				float y = player.transform.position.y;
				float z = player.transform.position.z;
				clone = (GameObject) Instantiate(this.targetChild, new Vector3(x, y + 9, z -10), Quaternion.Euler(new Vector3(30, 0, 0)));
				//clone.rigidbody.useGravity = false;
				clone.renderer.material.color = Color.magenta;
				//clone.rigidbody.freezeRotation = true;
				//clone.rigidbody.Sleep();

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

	//potential method for detecting offscreen objects
	//not working currently (raycasting via the camera is hard)
	void CheckVisible() {
		if(Camera.current != null) {
			Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
			//change second paramater to be more accurate
			Vector3 target = Camera.main.transform.position - transform.position;
			//Debug.DrawRay(transform.position, target, Color.red);

			//check if the position is on screen
			if(pos.z > 0 && pos.x >= 0.0f && pos.x <=1.0f && pos.y >= 0.0f && pos.y <=1.0f) {
				//check if it is obscured
				Ray ray = new Ray (transform.position, target);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, target.magnitude))
				{
					
					chooseNewIdentity();
					Debug.DrawRay(ray.origin, hit.point-ray.origin, Color.green);
					Debug.Log(gameObject.name + "is blocked by" + hit.collider.gameObject.name);

				}
				else
				{
					Debug.Log (gameObject.name + " is visible");
				}
			}
		}
	}


	//activates when another object enters the trigger area
	//note this is the "Is Trigger" box collider that has an independent size, NOT the one used for direct collisions
	void OnTriggerEnter(Collider other)
	{
		
		Debug.Log("Entered range");
		//only does something when the player enters the area
		if (other.gameObject.Equals (player) && !Input.GetButton("Jump")) {
			inRange = true;
			Renderer comp = targetChild.GetComponent<Renderer>();

			comp.material.color = (Color.yellow);
			Debug.Log("Entered range");

		}
	}

	void chooseNewIdentity()
	{
		ArrayList family = getFamily ();

		//choose from a random set of changes
		int r = Random.Range (0, family.Count);
		Debug.Log ("Child: " + targetChild);

		Debug.Log("Names:" + ((GameObject)family[r]).name + " " + targetChild.name);
		while(((GameObject)family[r]).name.Equals(targetChild.name)){
			r = Random.Range (0, family.Count);

		}
		Debug.Log ("Changed to : " + family[r]);

		clone = (GameObject) Instantiate(((GameObject)family[r]), targetChild.transform.position, targetChild.transform.rotation);
		clone.transform.parent = gameObject.transform;
		clone.renderer.material.color = Color.red;
		Destroy (targetChild);
		targetChild = clone;
		//Instantiate ((family[r]as GameObject));
	}

	//activates when another object exits the trigger area
	void OnTriggerExit(Collider other)
	{
		//only does something when the player enters the area
		if (other.gameObject.Equals (player)) {
			inRange = false;
			inspecting = false;
			Renderer comp = targetChild.GetComponent<Renderer>();
			
			comp.material.color = (Color.red);
			Debug.Log("Exited range");
		}
	}

	ArrayList getFamily()
	{
		GameObject[] prefabs = Resources.FindObjectsOfTypeAll (typeof(GameObject)) as GameObject[];
		ArrayList family = new ArrayList(); //List<GameObject> family = new List<GameObject> ();
		foreach(GameObject g in prefabs)
			if(g.CompareTag(targetChild.tag) && (PrefabUtility.GetPrefabParent(g) == null))
			   family.Add(g);
	    return family;
			   
	}

	void OnTriggerStay(Collider other)
	{
		
	}
}
