using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public bool isOn;
    private Animation cloud;

	// Use this for initialization
	void Start () {
        isOn = false;
        cloud = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
