using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{

    public UnityEngine.UI.Text cropDisplay;
    public float cropValue = 0;
    public CropUpgradeManager[] upgrades;
    private NumberConverter NC;

    void Start()
    {
        NC = new NumberConverter();
    }

    // Update is called once per frame
    void Update()
    {
        cropDisplay.text = NC.GetNumberIntoString(cropValue, true) + " Gold";
    }
}
