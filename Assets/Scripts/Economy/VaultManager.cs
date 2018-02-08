using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaultManager : MonoBehaviour {

    public Text vaultDiamonds;
    public float diamonds;
	
	// Update is called once per frame
	void Update () {
        vaultDiamonds.text = diamonds + " diamonds in vault";
	}
}
