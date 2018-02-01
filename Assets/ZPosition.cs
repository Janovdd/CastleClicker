using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPosition : MonoBehaviour {

    float x;
    float y;
    int z;
    Vector3 pos;

	// Use this for initialization
	void Start () {
        x = -6.8f;
        y = -6.8f;
        z = Random.Range(0, -10);
        pos= new Vector3(x, y, z);
        transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
