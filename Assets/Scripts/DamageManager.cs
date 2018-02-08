using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour {
    public Text dpsDisplay;
    private NumberConverter numberConverter;
    public float dps;

	// Use this for initialization
	void Start () {
        numberConverter = new NumberConverter();
		
	}
	
	// Update is called once per frame
	void Update () {
        dpsDisplay.text = numberConverter.GetNumberIntoString(dps, false) + " DPS";
	}

    
}
