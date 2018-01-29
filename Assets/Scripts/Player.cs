using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public GameObject troop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) {
		
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
		
			if (Physics.Raycast(raycast, out raycastHit)) {
				if (raycastHit.collider.CompareTag("playerCastle")) {
					Debug.Log("Soccer Ball clicked");
				}
			}
		}
		
		if(Input.GetMouseButtonDown(0)){
			Instantiate(troop); 
		}
		
	}
	
}