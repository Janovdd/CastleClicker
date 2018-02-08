using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : Enemy  {

	private IEnumerator coroutine;
	public int movementSpeed;
	public int dps;
	public int survivalTime;

	// Use this for initialization
	void Start () {
			StartCoroutine(waitSecond());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += movementSpeed * (Vector3.right * Time.deltaTime);
		if(transform.position.x > 930) {
			movementSpeed = 0;

		}
	}
	
	IEnumerator waitSecond(){
		while (survivalTime > 0) {
			doDamage();
			yield return new WaitForSeconds(1f);
		}
		Destroy(this.gameObject);
	}
	
	void doDamage(){
		GameObject.FindWithTag("enemyCastle").GetComponent<Enemy>().health -= dps;
		survivalTime = survivalTime - 1;
	}
	
}