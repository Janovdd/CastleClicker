using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour {

	public int movementSpeed;
	public int dps;
	public int survivalTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += movementSpeed * (Vector3.right * Time.deltaTime);
	}

}
