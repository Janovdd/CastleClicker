using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondManager : MonoBehaviour {

    public Text diamondDisplay;
    public float diamonds;
    public CropManager cropManager;
    public FarmerManager farmerManager;
    public ToolsManager toolsManager;

    // Update is called once per frame
    void Update()
    {
        diamondDisplay.text = diamonds + "";
    }
}
