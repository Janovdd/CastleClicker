using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPosition : MonoBehaviour {

    int z;
    Vector3 pos;

	// Use this for initialization
	void Start () {
        z = Random.Range(0, -6);
        pos= new Vector3(0, -48, z);
        transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
