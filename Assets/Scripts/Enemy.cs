using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public long health = 10000;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Troop")
			Destroy(coll.gameObject);
			Troop troop = GetComponent("Troop") as Troop;
			int st = troop.survivalTime;
			int dps = troop.dps;
			while (st > 0){
				health = health - dps;
				st = st - 1;
				//WaitForSeconds(1);
			}
    }
	
}