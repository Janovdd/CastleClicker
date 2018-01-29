using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public bool isOn;
    private bool setOn;
    private Animator cloud;

	// Use this for initialization
	void Start () {
        isOn = false;
        cloud = GetComponent<Animator>();
        cloud.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (isOn && !setOn)
        {
            setOn = true;
            cloud.enabled = true;
            var animation = cloud.GetComponent<Animation>();

        }
        if(!isOn && setOn)
        {
            setOn = false;
            cloud.enabled = false;
        }
	}
}
